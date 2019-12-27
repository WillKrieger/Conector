using System.Collections.Generic;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class InstanceHeader
    {
        public string instanceId { get; set; }

        public string agentUsername { get; set; }

        public IEnumerable<ContainerHeader> values { get; set; }
    }
}