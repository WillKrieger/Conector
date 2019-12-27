using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formiik.Connector.Data;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Entities.Mobile.Dto;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Logging;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.Processor.MobileProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Microsoft.Extensions.Options;

namespace Formiik.Connector.Processor.MobileProxy
{
    public class RequirementProcessor : IRequirementProcessor
    {
        private const string VALUES_ID_NAME = "values";
        private const string TRANSFORMATION_RULES_NOT_FOUND = "No hay reglas de transformación para el contenedor ({0})";
        private const string TRANSFORMATION_RESULT = "Resultado de la transformación ({0})";
        private const string WORK_ORDER_EXISTS_MESSAGE =
            "Solicita actualizar orden existente en formiik (UpdateExistsWorkOrdersId)";
        private const string IS_NEW_WORKORDER_MESSAGE =
            "Solicita crear una nueva orden en formiik (AddNewWorkOrderToUserName)";

        private const string INVALID_STATUS_RECEIVED =
            "Requisito no se procesa ({0}) porque el StatusContainer ({1}) no está permitido";

        private const string RULE_FOR_STATUS_IS_NOT_DEFINED =
            "No se ha definido una regla para el contenedor ({0}): statusContainer ({1}), customStatus ({2})";

        private const string MISSING_RULES_FOR_STATUS =
            "No se han configurado regla para los diferentes estados del contenedor ({0})";
        
        private static readonly string[] StatusAvailableToResponseInFormiik = { "A disposición", "Actualizada", "Recibida", "En dispositivo" };
        
        private readonly string _transactionId;

        private string _instanceId;

        private readonly FlexibleUpdateStorage _flexibleUpdateStorage;

        private readonly ApiEngineConfiguration _appConstants;

        public RequirementProcessor(IOptions<ApiEngineConfiguration> options)
        {
            _appConstants = options.Value;

            _transactionId = Guid.NewGuid().ToString();
            
            _flexibleUpdateStorage = new FlexibleUpdateStorage();
        }

        public async Task ProcessRequirementReceived(IncomeRequirementInfoDto request)
        {
            try
            {
                _instanceId = request.instanceId;
                Guard.AvoidNulls(request);
                Guard.AvoidNulls(request.values, VALUES_ID_NAME);
                Guard.AvoidStringNullOrEmpty(request.instanceId);

                bool isForFlexibleUpdate =
                    await _flexibleUpdateStorage.RequirementIsForFlexibleUpdate(request.instanceId, request);

                if (!isForFlexibleUpdate)
                {
                    KeyValuePair<TsRequirementTranformRule, TransformRuleByRequirementStatus> rule =
                        await GetTransformationRulesForStatus(request);

                    if (rule.Key != null && rule.Value != null)
                    {
                        TsRequirementTranformRule transformationRule = rule.Key;
                        TransformRuleByRequirementStatus ruleStatus = rule.Value;

                        NewWorkOrder newOrderInFormiik =
                            EngineToMobileTransformer.TransformToNewWorkOrder(request, transformationRule);

                        newOrderInFormiik = await CompleteNewOrder(newOrderInFormiik, request, ruleStatus);
                        LogInfo(string.Format(TRANSFORMATION_RESULT, request.containerId), newOrderInFormiik);
                        LogInfo($"IdWorkerOrderType {transformationRule.IdWorkOrderType}");
                        
                        await SendOrderToFormiik(newOrderInFormiik, request.instanceId, transformationRule.IdWorkOrderType);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                string errorId = LogError("No se pudo procesar el mensaje", ex);

                throw new InvalidOperationException($"ErrId: {errorId}");
            }
        }

        private async Task<NewWorkOrder> CompleteNewOrder(
            NewWorkOrder newOrderInFormiik,
            IncomeRequirementInfoDto request,
            TransformRuleByRequirementStatus dependency)
        {
            if (dependency.ContainersWhomDependOn != null && dependency.ContainersWhomDependOn.Count > 0)
            {
                foreach (string contanierId in dependency.ContainersWhomDependOn)
                {
                    try
                    {
                        IncomeRequirementInfoDto reqInfo = await GetRequirement(request.instanceId, contanierId);

                        if (reqInfo != null)
                        {
                            TsRequirementTranformRule subTransformationRule =
                                await TransformationRulesStorage.GetRuleEngineToMobile(contanierId, request.definitionId);

                            if (subTransformationRule != null)
                            {
                                NewWorkOrder complementOrder =
                                    EngineToMobileTransformer.TransformToNewWorkOrder(reqInfo, subTransformationRule);

                                foreach (var parametersVal in complementOrder.ParametersAsDictionary)
                                {
                                    if (!newOrderInFormiik.ParametersAsDictionary.ContainsKey(parametersVal.Key))
                                    {
                                        newOrderInFormiik.ParametersAsDictionary.Add(parametersVal.Key,
                                            parametersVal.Value);
                                    }
                                }
                            }
                            else
                            {
                                LogWarn(
                                    $"No se complementa la información, regla no encontrada para contenedor '{contanierId}' del que se depende.");
                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        throw;
                    }
                    catch (Exception e)
                    {
                        string errorId = LogError("No se pudo procesar el mensaje, error al obtener contenedores dependientes", e);

                        throw new InvalidOperationException($"ErrId: {errorId}");
                    }
                }
            }

            return newOrderInFormiik;
        }

        private async Task<IncomeRequirementInfoDto> GetRequirement(string instanceId, string containerId)
        {
            //var body = new {instanceId = instanceId, containerId = containerId};
            try
            {
                var GetRequirementAltUrl = "https://prod-09.southcentralus.logic.azure.com/workflows/08f0f5bbc2e9425bb89e6b5469bd1bfa/triggers/manual/paths/invoke/instances/{0}/{1}?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=bIFcxwenwEh7cOy1PnJ9uDJgSECG9CGPAORaK69lBUQ";
                                            
                //var url = string.Format(_appConstants.GetRequirementAltUrl, instanceId, containerId);
                var url = string.Format(GetRequirementAltUrl, instanceId, containerId);
                
                //TODO: Cambiar encabezados para que sean enviados desde mobile.
                var headers = new Dictionary<string, string>();
                headers.Add("channel", "mobile");
                
                headers.Add("ipaddress", "200.78.198.43");
                
                var reqResult = await RestServiceWrapper.ApiGet<IncomeRequirementInfoDto>(
                    url, headers);

                return reqResult;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(
                    $"No se pudo recuperar el requierimiento del que se depende: {containerId}", e);
            }
        }

        /// <summary>
        /// status to continue Flow in formiik
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private bool IsValidStatus(int status, string containerId)
        {
            bool isAcceptableStatus = status == EngineContainerStatus.CONTAINER_STATUS_OPEN 
                                     ||status == EngineContainerStatus.CONTAINER_STATUS_REJECTED;

            if (!isAcceptableStatus)
            {
                LogInfo(
                    String.Format(INVALID_STATUS_RECEIVED, containerId, status));
            }
            
            return isAcceptableStatus;
        }

        private async Task<KeyValuePair<TsRequirementTranformRule, TransformRuleByRequirementStatus>>
            GetTransformationRulesForStatus(IncomeRequirementInfoDto request)
        {
            TsRequirementTranformRule transformationRule = await TransformationRulesStorage. GetRuleEngineToMobile(request.containerId, request.definitionId);
            
            TransformRuleByRequirementStatus ruleStatus = null;

            if (transformationRule != null)
            {
                if (!string.IsNullOrEmpty(transformationRule.RulesApliedToStatusAsJson))
                {
                    var allSuleByStatus =
                        FormiikGenericParser.DeserializeFromJson<List<TransformRuleByRequirementStatus>>(
                            transformationRule.RulesApliedToStatusAsJson);

                    ruleStatus =
                        allSuleByStatus.FirstOrDefault(p =>
                            p.ExpectedCustomStatus == request.customStatusContainer &&
                            p.ExpecterStatusContainer == request.statusContainer);

                    if (ruleStatus == null)
                    {
                        LogInfo(string.Format(RULE_FOR_STATUS_IS_NOT_DEFINED, request.containerId,
                            request.statusContainer, request.customStatusContainer));
                    }
                }
                else
                {
                    LogInfo(string.Format(MISSING_RULES_FOR_STATUS, request.containerId));
                }
            }
            else
            {
                LogInfo(string.Format(TRANSFORMATION_RULES_NOT_FOUND, request.containerId));
            }

            return new KeyValuePair<TsRequirementTranformRule, TransformRuleByRequirementStatus>(transformationRule,
                ruleStatus);
        }

       

        #region - Asigment - 

        private async Task SendOrderToFormiik(NewWorkOrder newOrderInFormiik, string instanceId, string formType)
        {
            try
            {
                var workorderSvc = new WorkorderSvc();

                bool orderExistsInFormiik = await ExistsOrderInFormiik(newOrderInFormiik.ClientId, newOrderInFormiik.Id);

                if (orderExistsInFormiik)
                {
                    var idPackageUpdate = await workorderSvc.UpdateExistsWorkOrdersId(newOrderInFormiik);

                    LogInfo(WORK_ORDER_EXISTS_MESSAGE,
                        new {idPackageUpdate});
                }
                else
                {
                    string addNewWorkOrderToUserNameResponse =
                        await workorderSvc.AddNewWorkOrderToUserName(newOrderInFormiik);

                    LogInfo(IS_NEW_WORKORDER_MESSAGE,
                        new {addNewWorkOrderToUserNameResponse});
                }

                TsWorkorder workorderInfo =
                    await WorkOrderStorage.GetExistWorkorderByExternalId(formType,
                        instanceId);

                if (workorderInfo == null)
                {
                    await WorkOrderStorage.SaveNewWorkorder(
                        formType,
                        instanceId,
                        instanceId,
                        string.Empty,
                        newOrderInFormiik.UserName);
                }
            }
            catch (Exception e)
            {
                string errorId = LogError("No se pudo crear/actualizar la orden en formiik", e);

                throw new InvalidOperationException($"ErrId: {errorId}");
            }
        }

        #endregion
        private async Task<bool> ExistsOrderInFormiik(string clientId, string workorderExternalId)
        {   
            bool result = false;
            
            var workOrderSvc = new WorkorderSvc();

            List<FormiikStatusWorkOrder> existOrders = await workOrderSvc.GetWorkOrdersStateByExternalIds(clientId, workorderExternalId);

            if (existOrders != null && existOrders.Count > 0)
            {
                var exists = (from p in existOrders
                    where StatusAvailableToResponseInFormiik.Contains(p.OrderStatus)
                    select p);
                
                result = exists.Any();
            }
            
            return result;
        }
        
        #region - Simplificando el log -
 
        private void LogInfo(string message, object parameters = null)
        {
            ApplicationLogger.LogInfo(
                message,
                externalId:_instanceId,
                transactionId: _transactionId,
                parameters: parameters);
        }
        
        protected string LogError(string message, Exception ex, object parameters = null)
        {
            string errorId = ApplicationLogger.LogError(
                _instanceId,
                message,
                ex,
                transactionId: _transactionId,
                parameters: parameters);

            return errorId;
        }
        
        private void LogWarn(string message, object parameters = null)
        {
            ApplicationLogger.LogWarning(
                message,
                _instanceId,
                transactionId: _transactionId,
                parameters: parameters);
        }

        public async Task ProcessInstanceCancellation(IncomeInstanceCancelledDto request)
        {
            try
            {
                TsRequirementTranformRule transformationRule = await TransformationRulesStorage.GetRuleEngineToMobile(request.definitionId, request.definitionId);
                var workorderSvc = new WorkorderSvc();
                await workorderSvc.CancelWorkOrdersId(new CancelWorkOrder() { ClientId = transformationRule.ClientId, Id = request.instanceId, ProductId = transformationRule.ProductId });
                LogInfo($"DefinitionId to Cancel: {request.definitionId}");
            }
            catch (Exception ex)
            {
                string errorId = LogError($"No se pudo cancelar la orden {request.instanceId}", ex);
                throw new InvalidOperationException($"ErrId: {errorId}");
            }
        }

        #endregion
    }
}