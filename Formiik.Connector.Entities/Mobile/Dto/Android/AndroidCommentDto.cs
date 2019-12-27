using System;

namespace Formiik.Connector.Entities.Mobile.Dto.Android
{
    public class AndroidCommentDto
    {
        public string id { get; set; }
        
        public string text { get; set; }

        public DateTime date { get; set; }

        public string name { get; set; }

        public int status { get; set; }

        public bool isInformative { get; set; }
    }
}