using System;
using System.Threading.Tasks;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Logging.Entity;

namespace Formiik.Connector.Logging.Persistance
{
    public class EventLogRepository : IEventLogRepository
    {
        protected readonly AzureTableStorage<TSApplicationEvent> tableStorage;

        public EventLogRepository()
        {   
            var tableName = string.Format(
              "{0}{1}",
               GeneralConstants.TS_LOG_APPLICATION_EVENT,
              System.DateTime.UtcNow.ToString("MMyyyy"));

           
            this.tableStorage = new AzureTableStorage<TSApplicationEvent>(tableName);
        }

        /// <summary>
        /// Escribe un evento en la bitácora
        /// </summary>
        /// <param name="applicationEvent">Evento que se debe escribir en la bitácora</param>
        public async Task WriteEvent(TSApplicationEvent applicationEvent)
        {
            await this.tableStorage.Insert(applicationEvent);
        }
    }
}
