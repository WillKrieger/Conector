using System;
using System.Threading;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Logging;
using Formiik.Connector.Logging.Entity;
using Xunit;

namespace Formiik.Connector.ProcessorTests
{
    public class LogTest
    {
        protected readonly AzureTableStorage<TSApplicationEvent> Log;

        public LogTest()
        {
            var tableName = string.Format(
              "{0}{1}",
               GeneralConstants.TS_LOG_APPLICATION_EVENT,
              System.DateTime.UtcNow.ToString("MMyyyy"));
           
            this.Log = new AzureTableStorage<TSApplicationEvent>(tableName);
        }

        [Fact]
        public void LoggerEventWarning()
        {
            var rowKey = ApplicationLogger.LogWarning("Ya estoy loggeando", "201819251455", null, null);

            Thread.Sleep(10000);

            var partitionKey = string.Format("{0}{1}", EventType.Warning.ToString(), DateTime.UtcNow.ToString("ddMMyyyy"));

            var elements = this.Log.GetItem(partitionKey, rowKey);

            Assert.NotNull(elements);
        }
    }
}
