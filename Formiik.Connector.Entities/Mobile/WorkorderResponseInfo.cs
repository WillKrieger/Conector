using System;

namespace Formiik.Connector.Entities.Mobile
{
    public class WorkorderResponseInfo
    {
        public string AssignedTo { get; set; }

        public string ExternalId { get; set; }

        public string ExternalType { get; set; }

        public Guid IdWorkOrderType { get; set; }
        
    }
}