using System.Collections.Generic;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class SaveNewCommentsReqDto
    {
        public SaveNewCommentsReqDto()
        {
            comments = new List<CommentToSendDto>();    
        }
        
        public string containerId { get; set; }
        
        /// <summary>
        /// Task Id ( formiik: ExternalId)
        /// </summary>
        public string instanceId { get; set; }

        /// <summary>
        /// All new comments
        /// </summary>
        public List<CommentToSendDto> comments { get; set; }
        
    }
}