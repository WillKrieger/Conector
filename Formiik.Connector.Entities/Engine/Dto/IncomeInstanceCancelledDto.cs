using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class IncomeInstanceCancelledDto
    {
        public string agentUsername { get; set; }
        public string definitionId { get; set; }
        public string instanceId { get; set; }
        public string channel { get; set; }
    }
}