using System.Collections.Generic;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Logging.Entity;
using Xunit;

namespace DataTests
{
    public class TableStorageTest
    {
        readonly AzureTableStorage<TSApplicationEvent> ApplicationEvent;

        public TableStorageTest()
        {
            var tableName = string.Format(
              "{0}{1}",
               GeneralConstants.TS_LOG_APPLICATION_EVENT,
                System.DateTime.UtcNow.ToString("MMyyyy"));

            this.ApplicationEvent = new AzureTableStorage<TSApplicationEvent>(tableName);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteByPartitionKey()
        {
            string partitionKey = "Warning27102018";

            List<TSApplicationEvent> getAllRows;

            await this.DeleteTest(partitionKey);

            getAllRows = await this.ApplicationEvent.GetItems(partitionKey);

            Assert.True(getAllRows.Count == 0);

        }

        [Fact]
        public async System.Threading.Tasks.Task InsertRows()
        {
            string message = "Test";
            string externalId = "201819251455";
            var entities = new List<TSApplicationEvent>();
            int MAX_ROWS_TO_INSERT = 5;

            var warningEvent = new TSApplicationEvent();

            for (int i = 0; i < MAX_ROWS_TO_INSERT; i++)
            {
                warningEvent = new TSApplicationEvent(EventType.Warning.ToString(), message)
                {
                    ExternalId = externalId
                };

                entities.Add(warningEvent);
            }

            var tableResult = await ApplicationEvent.AddBatchRow(entities);

            Assert.True(tableResult.Count == MAX_ROWS_TO_INSERT);
        }

        [Fact]
        public async System.Threading.Tasks.Task ExecuteQuery()
        {
            const string QUERY = "PartitionKey eq '{0}'";
            const string PARTITIONKEY = "Warning29102018";

            var savedIdentity = await ApplicationEvent.ExecuteQuery(string.Format(QUERY, PARTITIONKEY), null);

            Assert.NotNull(savedIdentity);
        }

        private async System.Threading.Tasks.Task DeleteTest(string partitionKey)
        {
            await this.ApplicationEvent.DeletePartitionRows(partitionKey);
        }
    }
}
