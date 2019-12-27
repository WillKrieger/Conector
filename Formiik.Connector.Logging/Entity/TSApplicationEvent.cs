using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Logging.Entity
{
    public sealed class TSApplicationEvent : TableEntity
    {
        public TSApplicationEvent(){

        }

        public TSApplicationEvent(string eventType, string message)
        {
            this.EventId = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString().Substring(0, 8).ToUpper());
        
            this.EventType = eventType;

            this.EventDate = DateTime.UtcNow;

            this.Message = message;

            this.PartitionKey = this.EventDate.ToString("ddMMyyyy");

            this.FormiikClientId = string.Empty;

            this.TransactionId = string.Empty;

        }

        public string EventId
        {
            get { return this.RowKey; }
            set { this.RowKey = value; }
        }

        public string ExternalId { get; set; }
        
        public string FormiikClientId { get; set; }
        
        public string TransactionId { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string Message { get; set; }

        public string FunctionParameters { get; set; }

        public string UserName { get; set; }

        public string StackTrace { get; set; }
    }
}