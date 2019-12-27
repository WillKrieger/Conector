using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formiik.Connector.Entities.CustomExceptions;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.Processor.EngineProxy.Transformer;
using Formiik.Connector.Processor.MobileProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Microsoft.Extensions.Options;
using Polly;

namespace Formiik.Connector.Processor.EngineProxy
{
    public class FlexibleUpdateProcessor : ProcessorBase, IFlexibleUpdateProcessor
    {
        #region - Constants -

        private const string ERROR_AUTH = "Engine: Su sesión ha expirado.";
        private const string FLEXIBLE_UPDATE_PROCESS_MESSAGE_OK = "OK) Datos recibidos";
        private const string FLEXIBLE_UPDATE_ALREADY_RECEIVED_MESSAGE_OK = "OK) Datos recibidos previamente";

        private const string TRANSFORM_MESSAGE_SUCCESS = "Se ha transformado el mensaje de entrada";
        private const string START_FLEXIBLE_UPDATE = "Inicia solicitud de FlexibleUpdate";
        private const string MISSING_RESPONSE_FROM_ENGINE = "FU-Engine: Los requisitos esperados no están disponibles.";

        private const int SLEEP_SECOND_WAIT_FOR_ENGINE_NOTIFICATION = 1;
        private const int ATTEMPT_WAIT_FOR_ENGINE_NOTIFICATION = 10;
        
        private const int ATTEMPT_POLICY_FOR_GET_REQUIREMENT_FROM_ENGINE = 10;
        private const int SLEEP_FOR_GET_REQUIREMENT_FROM_ENGINE = 2;

        private const string MISSING_RULES_FOR_FLEXIBLE_UPDATE = "No se pudo ejecutar la acción, no hay relgas definidas para procesar la solicitud {0}";
        private const string EXTERNAL_ID_KEY = "ExternalId";

        #endregion

        private readonly FlexibleUpdateStorage _flexibleUpdateStorage;
        
        private readonly ApiEngineConfiguration _appConstants;
        
        public FlexibleUpdateProcessor(IOptions<ApiEngineConfiguration> options) : base(options)
        {
            _appConstants = options.Value;
            _flexibleUpdateStorage = new FlexibleUpdateStorage();
        }

        public async Task<FlexibleUpdateResponseDto> SendRequestToPlatform(Dictionary<string, string> incomeHeaders, FlexibleUpdateRequestDto request)
        {
            FlexibleUpdateResponseDto response;

            try
            {
                Guard.AvoidNulls(request);
                Guard.AvoidStringNullOrEmpty(request.ExternalId, EXTERNAL_ID_KEY);

                Init(incomeHeaders);
                
                LogExternalId = request.ExternalId;
                    
                LogInfo(START_FLEXIBLE_UPDATE, request);

                TsRequirementTranformRule rules =
                    await TransformationRulesStorage.GetRuleMobileToEngine(request.IdWorkOrderFormType, request.Action);

                if (rules != null)
                {
                    response = await ProcessRequest(request, rules);
                }
                else
                {
                    response = CreateMissingRulesResponse(request);
                }
            }
            catch (ApiUnautorizeException unAuth)
            {
                LogError(ERROR_AUTH, unAuth,
                    new {unAuth.ReqHeaders, unAuth.Url});

                response = new FlexibleUpdateResponseDto();

                var messageReservedWord = new FlexibleUpdateReservedWordsDto
                {
                    ReservedWord = FormiikConstants.RESERVEDWORD_ALERT_MESSAGE,
                    Value = ERROR_AUTH
                };

                response.FormiikReservedWords.Add(messageReservedWord);

                var clientError = new FlexibleUpdateReservedWordsDto(FormiikConstants.RESERVEDWORD_CLIENT_ERROR,
                    FormiikConstants.RESERVEDWORD_CLIENT_ERROR_VALUE);
                response.FormiikReservedWords.Add(clientError);
            }

            return response;
        }

        
        #region - Private Methods-

        private async Task<FlexibleUpdateResponseDto> ProcessRequest(FlexibleUpdateRequestDto request, TsRequirementTranformRule rules)
        {
            FlexibleUpdateResponseDto flexibleResult;
            
            InstanceInfo instanceInfo = await CreateInstanceIfNotExists(request.IdWorkOrderFormType, request.ExternalId, request.Username, rules.DefinitionId);

//            try
//            {
//                flexibleResult = await TryGetUpdateFromEngine(instanceInfo.instanceId, rules.ContainerId);
//            }
//            catch (MissingConfirmEngineEx)
//            {
            flexibleResult = await ProcessFlexibleUpdate(instanceInfo, request, rules);
//            }
                
            var instanceId = new FlexibleUpdateReservedWordsDto(FormiikConstants.RESERVEDWORD_ENGINE_INSTANCE_ID,
                instanceInfo.instanceId);

            var transactionId = new FlexibleUpdateReservedWordsDto(
                FormiikConstants.RESERVEDWORD_CONNECTOR_TRANSACTION_ID,
                TransactionId);

            flexibleResult.FormiikReservedWords.Add(instanceId);
            flexibleResult.FormiikReservedWords.Add(transactionId);

            return flexibleResult;
        }

        private FlexibleUpdateResponseDto CreateMissingRulesResponse(FlexibleUpdateRequestDto request)
        {
            FlexibleUpdateResponseDto flexibleResult;
            
            flexibleResult = new FlexibleUpdateResponseDto();

            var clientError = new FlexibleUpdateReservedWordsDto(
                FormiikConstants.RESERVEDWORD_CLIENT_ERROR,
                FormiikConstants.RESERVEDWORD_CLIENT_ERROR_VALUE);
                
            flexibleResult.FormiikReservedWords.Add(clientError);

            string error = string.Format(MISSING_RULES_FOR_FLEXIBLE_UPDATE, request.Action);
                    
            LogInfo(error);

            var partialSaveError = new FlexibleUpdateReservedWordsDto(
                FormiikConstants.RESERVEDWORD_ALERT_MESSAGE,
                error);

            flexibleResult.FormiikReservedWords.Add(partialSaveError);

            return flexibleResult;
        }
        
        private async Task<FlexibleUpdateResponseDto> ProcessFlexibleUpdate(
            InstanceInfo instanceInfo,
            FlexibleUpdateRequestDto request,
            TsRequirementTranformRule rules)
        {
            FUProcessResult processRequestResult = await SendRequestsToEngine(instanceInfo, request, rules);

            var flexibleResult = new FlexibleUpdateResponseDto();

            if (processRequestResult.Successful)
            {
                var userMessage = new StringBuilder();

                bool hasError = false;

                try
                {
                    List<TSFlexibleUpdateEngineResponses> processAlready = await Policy
                        .Handle<MissingConfirmEngineEx>()
                        .WaitAndRetryAsync(ATTEMPT_WAIT_FOR_ENGINE_NOTIFICATION,
                            retryAttempt => TimeSpan.FromSeconds(SLEEP_SECOND_WAIT_FOR_ENGINE_NOTIFICATION))
                        .ExecuteAsync(() => _flexibleUpdateStorage.GetProcessRowComplete(instanceInfo.instanceId));

                    flexibleResult.UpdateFieldsValues = await TransformResponse(processAlready);

                    _flexibleUpdateStorage.RemoveFlexibleUpdateCalls(instanceInfo.instanceId);

                    userMessage.Append(FLEXIBLE_UPDATE_PROCESS_MESSAGE_OK);
                }
                catch (MissingConfirmEngineEx)
                {
                    // second attempt to get flexible update response
                    try
                    {
                        flexibleResult = await Policy
                            .Handle<MissingConfirmEngineEx>()
                            .WaitAndRetryAsync(ATTEMPT_POLICY_FOR_GET_REQUIREMENT_FROM_ENGINE,
                                retryAttempt => TimeSpan.FromSeconds(SLEEP_FOR_GET_REQUIREMENT_FROM_ENGINE))
                            .ExecuteAsync(() => TryGetUpdateFromEngine(instanceInfo.instanceId, rules.ContainerId));

                        _flexibleUpdateStorage.RemoveFlexibleUpdateCalls(instanceInfo.instanceId);

                        userMessage.Append(FLEXIBLE_UPDATE_PROCESS_MESSAGE_OK);
                    }
                    catch (MissingConfirmEngineEx ex)
                    {
                        userMessage.Append(ex.Message);
                        hasError = true;
                    }
                }
                catch (Exception ex)
                {
                    userMessage.Append(ex.Message);
                    hasError = true;
                }

                var messageReservedWord = new FlexibleUpdateReservedWordsDto
                {
                    ReservedWord = FormiikConstants.RESERVEDWORD_ALERT_MESSAGE,
                    Value = userMessage.ToString()
                };

                flexibleResult.FormiikReservedWords.Add(messageReservedWord);

                if (hasError)
                {
                    var clientError = new FlexibleUpdateReservedWordsDto(FormiikConstants.RESERVEDWORD_CLIENT_ERROR,
                        FormiikConstants.RESERVEDWORD_CLIENT_ERROR_VALUE);
                    flexibleResult.FormiikReservedWords.Add(clientError);
                }
            }
            else
            {
                flexibleResult = TransformProcessResponse(processRequestResult);
            }

            return flexibleResult;
        }

        private async Task<FUProcessResult> SendRequestsToEngine(InstanceInfo instanceInfo,
            FlexibleUpdateRequestDto request, TsRequirementTranformRule rules)
        {
            var result = new FUProcessResult();

            result.ContainerSourceId = rules.ContainerId;

            TransformResult engineParameters =
                MobileToEngineTransformer.TransformFlexibleUpdate(request, rules.XsltTransformation,
                    rules.RemoveNullAndEmty, out StringBuilder warnTransform);

            LogInfo(TRANSFORM_MESSAGE_SUCCESS, new {engineParameters, warnTransform});

            result.PartialSaveError =
                await RemotePartialSaveRequirement(instanceInfo.instanceId, rules.ContainerId, engineParameters.Values);
            
            if (result.PartialSaveError == null)
            {
                await _flexibleUpdateStorage.WriteDefaultRowExpectation(instanceInfo.instanceId, LogExternalId, TransactionId);

                var awaitRules = await FlexibleUpdateConfigStorage.GetFlexibleUpdateConfig(rules.ContainerId);

                await _flexibleUpdateStorage.WriteResponseExpectation(instanceInfo.instanceId, LogExternalId,
                    TransactionId, awaitRules);

                var commentsErr = await SendComments(instanceInfo.instanceId, rules.ContainerId, engineParameters);

                result.NewCommentsErrror = commentsErr.Key;
                result.ConfirmCommentsErrror = commentsErr.Value;
                
                result.ProcessingError = await ProcessRemoteRequirement(instanceInfo.instanceId, rules.ContainerId);

                result.Successful = result.ProcessingError == null;
            }

            return result;
        }

        #region - Transform to flexible update-

        private FlexibleUpdateResponseDto TransformProcessResponse(FUProcessResult processRequestResult)
        {
            var flexibleResult = new FlexibleUpdateResponseDto();

            if (processRequestResult.Successful)
            {
                var userMessage = new FlexibleUpdateReservedWordsDto(FormiikConstants.RESERVEDWORD_ALERT_MESSAGE,
                    FLEXIBLE_UPDATE_PROCESS_MESSAGE_OK);

                flexibleResult.FormiikReservedWords.Add(userMessage);
            }
            else
            {
                var clientError = new FlexibleUpdateReservedWordsDto(
                    FormiikConstants.RESERVEDWORD_CLIENT_ERROR,
                    FormiikConstants.RESERVEDWORD_CLIENT_ERROR_VALUE);

                flexibleResult.FormiikReservedWords.Add(clientError);

                StringBuilder errorDetails = new StringBuilder();

                if (processRequestResult.PartialSaveError != null)
                {
                    errorDetails.Append($"Error en el guardado parcial: {processRequestResult.PartialSaveError}");
                }
                else if (processRequestResult.ProcessingError != null)
                {
                    errorDetails.Append($"Error al procesar el requisito: {processRequestResult.ProcessingError}");
                }

                var partialSaveError = new FlexibleUpdateReservedWordsDto(
                    FormiikConstants.RESERVEDWORD_ALERT_MESSAGE, errorDetails.ToString());

                flexibleResult.FormiikReservedWords.Add(partialSaveError);
            }

            return flexibleResult;
        }

        private async Task<Dictionary<string, string>> TransformResponse(
            List<TSFlexibleUpdateEngineResponses> engineResponses)
        {
            var result = new Dictionary<string, string>();

            foreach (var response in engineResponses)
            {
                if (!string.IsNullOrEmpty(response.EngineResponse))
                {
                    var engineIncomeData =
                        FormiikGenericParser.DeserializeFromJson<IncomeRequirementInfoDto>(response.EngineResponse);

                    Dictionary<string, string> part = await DeserializePart(engineIncomeData);

                    foreach (var item in part)
                    {
                        if (!result.ContainsKey(item.Key))
                        {
                            result.Add(item.Key, item.Value);
                        }
                    }
                }
            }

            return result;
        }

        private async Task<Dictionary<string, string>> DeserializePart(IncomeRequirementInfoDto engineIncomeData)
        {
            TsRequirementTranformRule xsltDef = await TransformationRulesStorage.GetRuleEngineToMobile(engineIncomeData.containerId, engineIncomeData.definitionId);

            var engineToFormiikParser = new EngineToMobileParser(engineIncomeData, xsltDef);

            Dictionary<string, string> orderParams = engineToFormiikParser.ToDictionaryValues();

            return orderParams;
        }

        #endregion

        #region - Async expected result-

       

        #endregion

        #region- Previous Req -

        private async Task<FlexibleUpdateResponseDto> TryGetUpdateFromEngine(string instanceId, string containerId)
        {
            FlexibleUpdateResponseDto response;

            var containerIsProcessed = await ContainerIsProcessed(instanceId, containerId);

            if (containerIsProcessed)
            {
                response = new FlexibleUpdateResponseDto();

                List<TSFlexibleUpdateEngineResponsesConfig> expectedRequirements =
                    await FlexibleUpdateConfigStorage.GetFlexibleUpdateConfig(containerId);

                var allAfectedFields = new Dictionary<string, string>();

                foreach (var requirement in expectedRequirements)
                {
                    IncomeRequirementInfoDto container = await GetRequirement(instanceId, requirement.ExpectedContanierId);

                    Dictionary<string, string> afectedFields = await DeserializePart(container);

                    LogInfo("Transformando requisito en affectedvalues", new {container, afectedFields});

                    foreach (var item in afectedFields)
                    {
                        if (!allAfectedFields.ContainsKey(item.Key))
                        {
                            allAfectedFields.Add(item.Key, item.Value);
                        }
                    }
                }

                response.UpdateFieldsValues = allAfectedFields;

                var messageReservedWord = new FlexibleUpdateReservedWordsDto
                {
                    ReservedWord = FormiikConstants.RESERVEDWORD_ALERT_MESSAGE,
                    Value = FLEXIBLE_UPDATE_ALREADY_RECEIVED_MESSAGE_OK
                };

                response.FormiikReservedWords.Add(messageReservedWord);

                LogInfo("Respuesta generado haciendo la consulta directa a Engine.", new {instanceId, containerId});
            }
            else
            {
                throw new MissingConfirmEngineEx(MISSING_RESPONSE_FROM_ENGINE);
            }

            return response;
        }

        private async Task<bool> ContainerIsProcessed(string instanceId, string containerId)
        {
            return false;
            bool readyProcesssed = false;

            try
            {
                var reqResult = await RestServiceWrapper.ApiGet<InstanceHeader>(
                    $"{_appConstants.GetRequirementByStatusUrl}{instanceId}",
                    HeadersForEngineRequest,
                    new Dictionary<string, string>()
                        {{"status", EngineContainerStatus.CONTAINER_STATUS_VALID.ToString()}});

                var exists = reqResult?.values?.FirstOrDefault(p => string.Equals(p.containerId, containerId));

                if (exists != null)
                {
                    readyProcesssed = true;
                }
            }
            catch (Exception e)
            {
                readyProcesssed = false;
                LogError("Error al obtener el contenedor", e, new {instanceId, containerId});
            }

            return readyProcesssed;
        }

        private async Task<IncomeRequirementInfoDto> GetRequirement(string instanceId, string containerId)
        {
            var reqResult = await RestServiceWrapper.ApiGet<IncomeRequirementInfoDto>(
                $"{_appConstants.GetRequirementUrl}{instanceId}/{containerId}", HeadersForEngineRequest);

            return reqResult;
        }

        #endregion

        #endregion
    }
}