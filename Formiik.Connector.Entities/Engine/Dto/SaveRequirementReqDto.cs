using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class SaveRequirementReqDto
    {
        public string containerId { get; set; }
        
        /// <summary>
        /// Task Id ( formiik: ExternalId)
        /// </summary>
        public string instanceId { get; set; }
        
        /// <summary>
        /// All values
        /// </summary>
        public JObject values { get; set; }
    }
}