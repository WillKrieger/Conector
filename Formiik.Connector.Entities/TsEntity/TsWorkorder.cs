using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Entities.TsEntity
{
    public class TsWorkorder : TableEntity
    {
        #region Properties

        public string IdWorkOrderType
        {
            get => PartitionKey;
            set => this.PartitionKey = value;
        }

        public string ExternalId
        {
            get => RowKey;
            set => this.RowKey = value;
        }

        public string InstanceId { get; set; }

        public string DefinitionId { get; set; }

        public string Username { get; set; }

        #endregion
    }
}