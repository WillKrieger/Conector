using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Entities.TsEntity
{
    /// <summary>
    /// Flexible update configuration request
    /// </summary>
    public class TSFlexibleUpdateEngineResponsesConfig : TableEntity
    {
        /// <summary>
        /// Client & container source id
        /// </summary>
        public string ConfigId
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        /// <summary>
        /// Container ID
        /// </summary>
        public string ExpectedContanierId
        {
            get => RowKey;
            set => RowKey = value;
        }

//        /// <summary>
//        /// Expected container response
//        /// </summary>
//        public string ExpectedContanierId { get; set; }

        /// <summary>
        /// True if response is required
        /// </summary>
        public bool ResponseIsRequired { get; set; }
    }
}