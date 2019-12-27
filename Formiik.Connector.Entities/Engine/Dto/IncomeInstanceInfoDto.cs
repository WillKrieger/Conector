using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class IncomeRequirementInfoDto
    {
        /// <summary>
        /// UserName who attend the task ( formiik: assignedTo)
        /// </summary>
        public string agentUsername { get; set; }

        /// <summary>
        /// Task Id ( formiik: ExternalId)
        /// </summary>
        public string instanceId { get; set; }

        /// <summary>
        /// Definition id from Engine
        /// </summary>
        public string definitionId { get; set; }
        
        /// <summary>
        /// Tenant Id from Engine 
        /// </summary>
        public string tenantId { get; set; }

        /// <summary>
        /// If of instance type in Engine
        /// </summary>
        public string containerId { get; set; }

        public int status { get; set; }

        /// <summary>
        /// see <see cref="EngineContainerStatus"/>
        /// </summary>
        public int statusContainer { get; set; }
        
        /// <summary>
        /// All field values ( formiik: Parameters)
        /// </summary>
        public JObject values { get; set; }
        
        /// <summary>
        /// Array of comments
        /// </summary>
        public List<IncomeCommmentDto> comments { get; set; }

        /// <summary>
        /// Custom status in of requirement in engine
        /// </summary>
        public int customStatusContainer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string action { get; set; }
    }
}