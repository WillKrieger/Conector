using System.Collections.Generic;

namespace Formiik.Connector.Entities.Mobile
{
    public class NewWorkOrder
    {
        public string Id { get; set; }

        public string ClientId { get; set; }

        public string ProductId { get; set; }
        
        public string ContainerId { get; set; }

        public string Type { get; set; }

        public string Version { get; set; }

        public string UserName { get; set; }

        public int Priority { get; set; }

        public string ExpirationDate { get; set; }

        public string CancellationDate { get; set; }

        public Dictionary<string, string> ParametersAsDictionary { get; set; }
    }
}