using System.Collections.Generic;
using System.Threading.Tasks;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.TsEntity;

namespace Formiik.Connector.Processor.ConnectorStorage
{
    public static class FlexibleUpdateConfigStorage
    {
        public static async Task<List<TSFlexibleUpdateEngineResponsesConfig>> GetFlexibleUpdateConfig(string containerId)
        {
            string configurationId = $"{containerId}";
            
            var configTable = GetConnection();
            
            List<TSFlexibleUpdateEngineResponsesConfig> expectedRequirements =
                await configTable.GetItems(configurationId);

            return expectedRequirements;
        }

        private static AzureTableStorage<TSFlexibleUpdateEngineResponsesConfig> GetConnection()
        {
            var configTable =
                new AzureTableStorage<TSFlexibleUpdateEngineResponsesConfig>(GeneralConstants
                    .TS_FLEXIBLE_UPDATE_ENGINE_RESPONSES_CONFIG);

            return configTable;
        }

    }
}