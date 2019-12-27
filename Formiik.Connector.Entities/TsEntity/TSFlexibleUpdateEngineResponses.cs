using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Entities.TsEntity
{
    /// <summary>
    /// Engine responses ( Requirements received from formiik engine )
    /// </summary>
    public class TSFlexibleUpdateEngineResponses: TableEntity
    {
        public string InstanceId
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }
        
        /// <summary>
        /// Container ID
        /// </summary>
        public string ContainerId
        {
            get => RowKey;
            set => RowKey = value;
        }

        /// <summary>
        /// Set true if connector expected engine notification
        /// </summary>
        public bool ResponseIsRequired { get; set; }

        public string WorkorderId { get; set; }
        
        public string TransactionId { get; set; }

        #region - Fields for engine response-

        /// <summary>
        /// Se true if engine notify response
        /// </summary>
        public bool Done { get; set; }
        
        /// <summary>
        /// JSON of engine response
        /// </summary>
        public string EngineResponse { get; set; }  

        #endregion      
    }
}