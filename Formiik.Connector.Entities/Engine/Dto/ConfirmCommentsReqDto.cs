using System.Collections.Generic;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class ConfirmCommentsReqDto
    {
        public ConfirmCommentsReqDto()
        {
            commentIds = new List<string>();    
        }
        
        public string containerId { get; set; }
        
        /// <summary>
        /// Task Id ( formiik: ExternalId)
        /// </summary>
        public string instanceId { get; set; }

        /// <summary>
        /// All new comments
        /// </summary>
        public List<string> commentIds { get; set; }
    }
}