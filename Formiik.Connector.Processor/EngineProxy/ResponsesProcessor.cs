using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.CustomExceptions;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.Processor.EngineProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.EngineProxy
{
    public class ResponsesProcessor : ProcessorBase, IResponsesProcessor
    {
        private const string TRANSFORM_MESSAGE_SUCCESS = "Transformando XMLResponse ('{0}')";
        private string START_PROCESS_RESPONSE = "Inicia el procesamiento de XMLResponse";

        private readonly ApiEngineConfiguration _appConstants;

        public ResponsesProcessor(IOptions<ApiEngineConfiguration> options) : base(options)
        {
            _appConstants = options.Value;
        }
                
        public async Task<string> ProcessResponse(Dictionary<string, string> incomeHeaders, string xmlResponse)
        {
            string errorDetails;

            Guard.AvoidStringNullOrEmpty(xmlResponse);

            XmlDocument responseDoc = ParseXml(xmlResponse);

            WorkorderResponseInfo orderInfo = ExtractWorkorderInfo(responseDoc);

            LogInfo(START_PROCESS_RESPONSE);

            Init(incomeHeaders);

            // In case missing instance ID
            LogExternalId = orderInfo.ExternalId;

            errorDetails = await ProcessResponseParts(orderInfo, responseDoc);

            return errorDetails;
        }

        #region - Transformation -

        private XmlDocument ParseXml(string xmlResponse)
        {
            XmlDocument responseDoc = new XmlDocument();

            try
            {
                responseDoc.LoadXml(xmlResponse);
            }
            catch (Exception e)
            {
                throw new ManagedException($"Invalid XML {e}");
            }

            return responseDoc;
        }

        private WorkorderResponseInfo ExtractWorkorderInfo(XmlDocument response)
        {
            var orderInfo = new WorkorderResponseInfo();

            var single = response.SelectSingleNode("Response");

            orderInfo.AssignedTo = single.Attributes["AssignedTo"]?.Value;
            orderInfo.ExternalId = single.Attributes["ExternalId"].Value;
            orderInfo.ExternalType = single.Attributes["ExternalType"].Value;
            orderInfo.IdWorkOrderType = new Guid(single.Attributes["IdWorkOrderFormType"].Value);
            
            //TODO: Quitar esta linea, solo es para pruebas
            LogInfo($"For test, IdWorkOrderFormType: {orderInfo.IdWorkOrderType}");
            
            return orderInfo;
        }

        #endregion

        #region - Processing data -

        private async Task<string> ProcessResponseParts(WorkorderResponseInfo responseInfo, XmlDocument responseDoc)
        {
            string processResult = string.Empty;

            XmlNodeList sections = responseDoc.SelectNodes("/*/*/*");

            InstanceInfo instanceInfo = null;

            foreach (XmlNode section in sections)
            {
                TsRequirementTranformRule rules =
                    await TransformationRulesStorage.GetRuleMobileToEngine(responseInfo.IdWorkOrderType, section.Name);

                if (instanceInfo == null)
                {
                    instanceInfo = await this.CreateInstanceIfNotExists(
                        responseInfo.IdWorkOrderType,
                        responseInfo.ExternalId,
                        responseInfo.AssignedTo,
                        rules.DefinitionId);
                }
                
                if (rules != null)
                {
                    await ProcessSection(instanceInfo, rules, $"<root>{section.InnerXml}</root>");
                }
            }

            CleanFlexibleupdateCalls(instanceInfo.instanceId, responseInfo.ExternalId);
            
            return processResult;
        }

        private async Task ProcessSection(InstanceInfo instanceInfo, 
            TsRequirementTranformRule rules,
            string secctionXml)
        {
            bool canSenDataToProcess = CanProcessInstance(instanceInfo.instanceId, rules.ContainerId);

            if (canSenDataToProcess)
            {
                try
                {
                    TransformResult engineParameters =
                        MobileToEngineTransformer.TransformResponse(secctionXml, rules.XsltTransformation,
                            rules.RemoveNullAndEmty, out var warnTransform);

                    LogInfo(string.Format(TRANSFORM_MESSAGE_SUCCESS, rules.ContainerId),
                        new {engineParameters, warnTransform = warnTransform.ToString()});

                    GenericErrorApiEngineResDto partialSaveError =
                        await this.RemotePartialSaveRequirement(instanceInfo.instanceId, rules.ContainerId,
                            engineParameters.Values);

                    if (partialSaveError != null)
                    {
                        LogWarning($"Error) XMLResponse: Solicitud de guardado parcial ({rules.ContainerId})",
                            new {partialSaveError, values = engineParameters});
                    }
                    else
                    {
                        await SendComments(instanceInfo.instanceId, rules.ContainerId, engineParameters);

                        GenericErrorApiEngineResDto processReqResult =
                            await this.ProcessRemoteRequirement(instanceInfo.instanceId, rules.ContainerId);

                        if (processReqResult != null)
                        {
                            LogWarning($"Error) XMLResponse: En solicitud de procesar contenedor ({rules.ContainerId})",
                                new {processReqResult, values = engineParameters});
                        }
                        else
                        {
                            LogInfo($"OK) XMLResponse: El contenedor ({rules.ContainerId}) se ha enviado a procesar");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(PROCESS_SLEEP_IN_SECONDS));
                        }
                    }
                }
                catch (Exception e)
                {
                    LogError($"Error) XMLResponse: No se pudo procesar el contenedor ({rules.ContainerId})", e);
                }
            }
            else
            {
                LogInfo(
                    $"XMLResponse: Engine indica que '{rules.ContainerId}' se encuentra en estatus {EngineContainerStatus.CONTAINER_STATUS_VALID}, NO se requiere guardado parcial y procesamiento.",
                    new {instanceInfo.instanceId, rules.ContainerId});
            }
        }

        #endregion

        private bool CanProcessInstance(string instanceId, string containerId)
        {
            bool canProcessInstance = true;
//
//            if (_instanceData == null)
//            {
//                try
//                {
//                    _instanceData = await RestServiceWrapper.ApiGet<HeaderInstance>(
//                        $"{PlatformConstants.GET_INSTANCE_URL}{instanceId}",
//                        HeadersForEngineRequest);
//                }
//                catch (Exception e)
//                {
//                    LogError("Error) XMLResponse: Al obtener la instancia", e, new {instanceId});
//                }
//            }
//            
//            if (_instanceData?.values?.containers != null)
//            {
//                foreach (var keyVal in _instanceData.values.containers)
//                {
//                    if (keyVal.Key == containerId)
//                    {
//                        var container = keyVal.Value;
//                    }
//                }
//            }
            
            return canProcessInstance;
        }

        private void CleanFlexibleupdateCalls(string instanceId, string externalId)
        {
            FlexibleUpdateStorage flexibleUpdateStorage = new FlexibleUpdateStorage();

            flexibleUpdateStorage.RemoveFlexibleUpdateCalls(instanceId, true);

            if (!string.Equals(instanceId, externalId))
            {
                flexibleUpdateStorage.RemoveFlexibleUpdateCalls(externalId, true);
            }
            
        }
    }
}