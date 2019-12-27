using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.CustomExceptions;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Logging;
using Formiik.Connector.Processor.Utils;

namespace Formiik.Connector.Processor.ConnectorStorage
{
    internal class FlexibleUpdateStorage
    {
        private const string EXPECTED_FU_RECEIVED = "Se recibió respuesta de container (FU Esperado)";
        private const string DEFAULT_CONTAINER_FLEXIBLE_UPDATE_ROW = "$DEFAULT-CONTAINER-ROW-FU$";
        private const string MISSING_RESPONSE_FROM_ENGINE = "FU-Engine: Los requisitos esperados no están disponibles.";
        
        private readonly AzureTableStorage<TSFlexibleUpdateEngineResponses> _tableOfRequirementExpected;
        
        public FlexibleUpdateStorage()
        {
            _tableOfRequirementExpected =
                new AzureTableStorage<TSFlexibleUpdateEngineResponses>(GeneralConstants
                    .TS_FLEXIBLE_UPDATE_ENGINE_RESPONSES);
        }
        
        public void RemoveFlexibleUpdateCalls(string instanceId, bool deleteDefault = false)
        {
            try
            {
                Task.Factory.StartNew(() => RemoveResponseExpectation(instanceId, deleteDefault));
            }
            catch
            {
            }
        }
        
        /// <summary>
        /// Get rows response confirmed
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        /// <exception cref="MissingConfirmEngineEx">If any of require responses is not received from engine</exception>
        public async Task<List<TSFlexibleUpdateEngineResponses>> GetProcessRowComplete(string instanceId)
        {
            List<TSFlexibleUpdateEngineResponses> expectedResponses =
                await _tableOfRequirementExpected.GetItems(instanceId);

            if (expectedResponses.Any())
            {
                var responsesReceived = expectedResponses.Count(p => p.Done);
                var responsesRequired = expectedResponses.Count(p => p.ResponseIsRequired);

                if (responsesReceived < responsesRequired)
                {
                    throw new MissingConfirmEngineEx(MISSING_RESPONSE_FROM_ENGINE);
                }
            }

            return expectedResponses;
        }
        
        public async Task WriteDefaultRowExpectation(string instanceId, string workOrderExternalId, string transactionId)
        {
            var items = await _tableOfRequirementExpected.GetItems(instanceId);

            if (!items.Any())
            {
                var expectedResult = new TSFlexibleUpdateEngineResponses();
                expectedResult.WorkorderId = workOrderExternalId;
                expectedResult.TransactionId = transactionId;

                expectedResult.InstanceId = instanceId;
                expectedResult.ContainerId = DEFAULT_CONTAINER_FLEXIBLE_UPDATE_ROW;
                expectedResult.Done = false;
                expectedResult.ResponseIsRequired = false;
                expectedResult.EngineResponse = string.Empty;
                await _tableOfRequirementExpected.Insert(expectedResult);
            }
        }

        internal async Task<bool> RequirementIsForFlexibleUpdate(string instanceId, IncomeRequirementInfoDto request)
        {
            bool exists;

            var connectionFlexibleTrack =
                new AzureTableStorage<TSFlexibleUpdateEngineResponses>(GeneralConstants
                    .TS_FLEXIBLE_UPDATE_ENGINE_RESPONSES);

            List<TSFlexibleUpdateEngineResponses> expectedResponses = await connectionFlexibleTrack.GetItems(instanceId);
            
            var existItem = expectedResponses.FirstOrDefault(p => p.ContainerId == request.containerId);
            
            if (existItem != null)
            {
                exists = true;
                existItem.Done = true;
                existItem.EngineResponse = FormiikGenericParser.SerializeToJson(request);
                await connectionFlexibleTrack.Update(existItem);

                ApplicationLogger.LogInfo(EXPECTED_FU_RECEIVED, instanceId, existItem.TransactionId);
            }
            else
            {
                exists = expectedResponses.Any();

                if (exists)
                {
                    ApplicationLogger.LogInfo("Se recibió respuesta de container (FU NO esperado)", instanceId);
                }
            }

            return exists;
        }
        
        /// <summary>
        /// Write expectation responses
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="transactionId"></param>
        /// <param name="expectedRequirements"></param>
        /// <param name="workOrderExternalId"></param>
        /// <returns></returns>
        public async Task WriteResponseExpectation(
            string instanceId,
            string workOrderExternalId,
            string transactionId,
            List<TSFlexibleUpdateEngineResponsesConfig> expectedRequirements)
        {
            if (expectedRequirements.Any())
            {
                foreach (var expectedRequirement in expectedRequirements)
                {
                    var currentRow =
                        await _tableOfRequirementExpected.GetItem(instanceId, expectedRequirement.ExpectedContanierId);

                    if (currentRow != null)
                    {
                        currentRow.Done = false;
                        currentRow.ResponseIsRequired = expectedRequirement.ResponseIsRequired;
                        currentRow.Done = false;
                        currentRow.EngineResponse = string.Empty;
                        currentRow.WorkorderId = workOrderExternalId;
                        currentRow.TransactionId = transactionId;

                        await _tableOfRequirementExpected.Update(currentRow);
                    }
                    else
                    {
                        var expectedResult = new TSFlexibleUpdateEngineResponses();
                        expectedResult.InstanceId = instanceId;
                        expectedResult.ContainerId = expectedRequirement.ExpectedContanierId;
                        expectedResult.ResponseIsRequired = expectedRequirement.ResponseIsRequired;
                        expectedResult.WorkorderId = workOrderExternalId;
                        expectedResult.TransactionId = transactionId;

                        expectedResult.Done = false;
                        expectedResult.EngineResponse = string.Empty;
                        await _tableOfRequirementExpected.Insert(expectedResult);
                    }
                }
            }
        }

        private async Task RemoveResponseExpectation(string instanceId, bool deleteDefault)
        {
            try
            {
                var items = await _tableOfRequirementExpected.GetItems(instanceId);

                foreach (var item in items)
                {
                    bool isDefaultRow = string.Equals(item.ContainerId, DEFAULT_CONTAINER_FLEXIBLE_UPDATE_ROW);

                    if (isDefaultRow)
                    {
                        if (deleteDefault)
                        {
                            await _tableOfRequirementExpected.Delete(item.PartitionKey, item.RowKey);
                        }
                    }
                    else
                    {
                        await _tableOfRequirementExpected.Delete(item.PartitionKey, item.RowKey);    
                    }
                }
            }
            catch
            {
                ApplicationLogger.LogWarning("Error al limpiar los flexibles", instanceId);
            }
        }
    }
}