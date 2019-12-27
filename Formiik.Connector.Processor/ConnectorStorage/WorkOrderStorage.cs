using System.Threading.Tasks;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.TsEntity;

namespace Formiik.Connector.Processor.ConnectorStorage
{
    internal static class WorkOrderStorage
    {
        internal static async Task<TsWorkorder> GetExistWorkorderByExternalId(string idWorkOrderType, string externalId)
        {
            var table =  GetConection();

            TsWorkorder savedWorkorder = await table.GetItem(idWorkOrderType, externalId);

            return savedWorkorder;
        }
        
        /// <summary>
        /// Save instance info in local repositorio
        /// </summary>
        /// <param name="idWorkOrderType"></param>
        /// <param name="externalId"></param>
        /// <param name="instanceId"></param>
        /// <param name="definitionId"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        internal static async Task SaveNewWorkorder(
            string idWorkOrderType, 
            string externalId, 
            string instanceId, 
            string definitionId,
            string username)
        {
            var table = GetConection();

            var newRecord = new TsWorkorder()
            {
                IdWorkOrderType = idWorkOrderType,
                ExternalId = externalId,
                InstanceId = instanceId,
                DefinitionId = definitionId,
                Username = username
            };

            await table.Insert(newRecord);
        }

        private static AzureTableStorage<TsWorkorder> GetConection()
        {
            return new AzureTableStorage<TsWorkorder>(GeneralConstants.TS_WORK_ORDERS);
        }
    }
}