using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.CustomExceptions;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Logging;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.Processor.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.EngineProxy
{
    public abstract class ProcessorBase
    {
        private int PARTIAL_SAVE_SLEEP_IN_SECONDS = 3;
        private const string REQUEST_DONE = "{0} -> {1}";
        private const string REQUEST_ERROR = "{0} -> {1}";
        private const string NEW_INSTANCE_CREATED = "Se ha creado una nueva instancia";

        protected int PROCESS_SLEEP_IN_SECONDS = 3;
        
        protected Dictionary<string, string> HeadersForEngineRequest;

        protected string TransactionId { get; private set; }

        protected string LogExternalId { get; set; }
        
        //protected string FormiikClientId { get; set; }
        
        private readonly ApiEngineConfiguration _appConstants;

        protected ProcessorBase(IOptions<ApiEngineConfiguration> options)
        {
            _appConstants = options.Value;
            LogExternalId = string.Empty;
        }
        
        protected void Init(Dictionary<string, string> incomeHeaders)
        {
            TransactionId = $"{DateTime.UtcNow:ddMMyyyyHHmmss}_{Guid.NewGuid().ToString().Substring(0, 4)}";
            
            HeadersForEngineRequest = new Dictionary<string, string>();

            this.SetHeadersForEngineRequest(incomeHeaders);
        }

        #region - Create Instance -

        /// <summary>
        /// Create new remote instance if not exists
        /// </summary>
        /// <param name="formTypeId">id in SQL formiik: WorkOrderType.IdWorkOrderType</param>
        /// <param name="externalId">Workorder external identifier</param>
        /// <param name="username">username of user have assigned order</param>
        /// <param name="definitionId"></param>
        /// <returns>Null if never have been processed info about externalid</returns>
        protected async Task<InstanceInfo> CreateInstanceIfNotExists(Guid formTypeId, string externalId, string username, string definitionId)
        {
            InstanceInfo instanceInfo = null;

            string formTypeAsSting = formTypeId.ToString().ToLower();
            
            TsWorkorder savedInstance =
                await WorkOrderStorage.GetExistWorkorderByExternalId(formTypeAsSting, externalId);

            if (savedInstance == null)
            {
                var reqNewInstance = new NewInstanceReqDto();
                reqNewInstance.definitionId = definitionId;

                instanceInfo = await CreateRemoteInstance(reqNewInstance);

                await WorkOrderStorage.SaveNewWorkorder(
                    formTypeAsSting,
                    externalId,
                    instanceInfo.instanceId,
                    instanceInfo.definitionId,
                    username);
                
                // double create order for search an check
                await WorkOrderStorage.SaveNewWorkorder(
                    formTypeAsSting,
                    instanceInfo.instanceId,
                    instanceInfo.instanceId,
                    instanceInfo.definitionId,
                    username);
                
                LogInfo(NEW_INSTANCE_CREATED, instanceInfo);
            }
            else
            {
                instanceInfo = new InstanceInfo();
                instanceInfo.definitionId = definitionId;
                instanceInfo.instanceId = savedInstance.InstanceId;
            }

            return instanceInfo;
        }

        /// <summary>
        /// Send request to engine for creation instance
        /// </summary>
        /// <param name="newInstanceReq">New instance data. <see cref="NewInstanceReqDto"/></param>
        /// <returns></returns>
        private async Task<InstanceInfo> CreateRemoteInstance(NewInstanceReqDto newInstanceReq)
        {
            var newInstanceResponse = await RestServiceWrapper.ApiPost<NewInstanceRespDto>(
                _appConstants.CreateInstancesUrl,
                HeadersForEngineRequest,
                newInstanceReq
            );

            // TODO: GMA remove this sleep when everything works ( test with Mau) 
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(PROCESS_SLEEP_IN_SECONDS));

            var newInstanceInfo = new InstanceInfo
            {
                instanceId = newInstanceResponse.instanceId,
                definitionId = newInstanceResponse.definitionId
            };

            if (string.IsNullOrEmpty(newInstanceInfo.definitionId))
            {
                // TODO: esto es porque el servicio ya no regresa el definition id
                newInstanceInfo.definitionId = newInstanceReq.definitionId;
            }

            return newInstanceInfo;
        }

        #endregion

        #region - Requirement -

        protected async Task<GenericErrorApiEngineResDto> RemotePartialSaveRequirement(
            string instanceId,
            string containerId,
            JObject values)
        {
            var reqUpdateInstance = new SaveRequirementReqDto
            {
                instanceId = instanceId, 
                containerId = containerId, 
                values = values
            };

            GenericErrorApiEngineResDto errorDetails =
                await SendHttpPutRequest(_appConstants.PartialSaveRequirementUrl, reqUpdateInstance,
                    $"Guardado parcial requisito ({containerId})");

            if (errorDetails == null)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(PARTIAL_SAVE_SLEEP_IN_SECONDS));    
            }
            
            return errorDetails;
        }

        protected async Task<GenericErrorApiEngineResDto> ProcessRemoteRequirement(string instanceId, string containerId)
        {
            var reqProcess = new ProcessRequirementReqDto()
            {
                instanceId = instanceId,
                containerId = containerId
            };


            GenericErrorApiEngineResDto errorDetails =
                await SendHttpPutRequest(_appConstants.ProcessRequirementUrl, reqProcess,
                    $"Procesa requisito ({containerId})");

            return errorDetails;
        }

        private async Task<GenericErrorApiEngineResDto> SendHttpPutRequest(string url, object data, string logMessage)
        {
            GenericErrorApiEngineResDto error = null;

            try
            {
                GenericApiEngineResDto response = await RestServiceWrapper.SendHttpPutRequest(url, HeadersForEngineRequest, data);

                string message = string.Format(REQUEST_DONE, logMessage, url);

                LogInfo(message, response);
            }
            catch (ApiEngineCallException apiEx)
            {
                LogError(string.Format(REQUEST_ERROR, logMessage, url), apiEx,
                    new {request = data, response = apiEx.ResponseContent});
                
                error = RestServiceWrapper.ExtractHttpErrorDetails(apiEx.ResponseContent);
            }

            return error;
        }

        #endregion
        
        #region - Comments -
        protected async Task<KeyValuePair<GenericErrorApiEngineResDto, GenericErrorApiEngineResDto>> SendComments(
            string instanceId,
            string containerId,
            TransformResult engineParameters)
        {
            GenericErrorApiEngineResDto newCommentsErrors = null;
            GenericErrorApiEngineResDto confirmCommentsErrors = null;

            if (engineParameters.NewComments.Count > 0)
            {
                var newCommentsReq = new SaveNewCommentsReqDto
                {
                    instanceId = instanceId, 
                    containerId = containerId
                };
                
                foreach (var comment in engineParameters.NewComments)
                {
                    newCommentsReq.comments.Add(new CommentToSendDto()
                    {
                        keyName = comment.Key, 
                        description = comment.Value
                    });
                }

                newCommentsErrors =
                    await SendHttpPutRequest(_appConstants.NewCommentsUrl, newCommentsReq, $"{containerId}, Nuevos comentarios");

                if (newCommentsErrors == null)
                {
                    LogInfo("OK) Nuevos comentarios agregados");
                }
                else
                {
                    LogWarning("Error al guardar los nuevos comentarios", newCommentsErrors);
                }
            }
            
            if (engineParameters.ResolveComments.Count > 0)
            {
                var confirmCommentsReq = new ConfirmCommentsReqDto
                {
                    instanceId = instanceId, 
                    containerId = containerId
                };
                
                foreach (var comment in engineParameters.ResolveComments)
                {
                    confirmCommentsReq.commentIds.Add(comment.Value);
                }

                confirmCommentsErrors =
                    await SendHttpPutRequest(_appConstants.ResolveCommentsUrl, confirmCommentsReq, $"{containerId}, Confirmar comentarios");

                if (confirmCommentsErrors == null)
                {
                    LogInfo("OK) Confirmar comentarios");
                }
                else
                {
                    LogWarning("Error al confirmar comentarios", newCommentsErrors);
                }
            }
            


            return new KeyValuePair<GenericErrorApiEngineResDto, GenericErrorApiEngineResDto>(newCommentsErrors,
                confirmCommentsErrors);
        }
        #endregion

        #region - Rules -

        #endregion

        #region - Simplificando el log -

        protected void LogWarning(string message, object parameters = null)
        {
            ApplicationLogger.LogWarning(
                message,
                LogExternalId,
                transactionId: TransactionId,
                parameters: parameters);
        }
        
        protected void LogInfo(string message, object parameters = null)
        {
            ApplicationLogger.LogInfo(
                message,
                LogExternalId,
                transactionId: TransactionId,
                parameters: parameters);
        }
        
        protected string LogError(string message, Exception ex, object parameters = null)
        {
            string errorId = ApplicationLogger.LogError(
                LogExternalId,
                message,
                ex,
                transactionId: TransactionId,
                parameters: parameters);

            return errorId;
        }

        #endregion
        
        #region - Private methods-

        /// <summary>
        /// Prepare headers for sent to platform request 
        /// </summary>
        /// <param name="incomeHeaders"></param>
        /// <returns></returns>
        private void SetHeadersForEngineRequest(Dictionary<string, string> incomeHeaders)
        {
            if (incomeHeaders != null)
            {
                if (incomeHeaders.TryGetValue(_appConstants.AuthorizationHeader, out var authHeader))
                {
                    HeadersForEngineRequest.Add(_appConstants.AuthorizationHeader, authHeader);
                }
            }

            if (!HeadersForEngineRequest.ContainsKey(_appConstants.HeaderSuscriptionKey))
            {
                HeadersForEngineRequest.Add(_appConstants.HeaderSuscriptionKey, _appConstants.HeaderSuscriptionValue);
            }
        }

        #endregion
    }
}