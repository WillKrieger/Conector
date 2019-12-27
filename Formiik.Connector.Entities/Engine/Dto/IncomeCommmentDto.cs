using System;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class IncomeCommmentDto
    {
        public string commentId { get; set; }

        /// <summary>
        /// field path
        /// </summary>
        public string keyName { get; set; }

        public string description { get; set; }

        public DateTime creation { get; set; }

        public bool isInformative { get; set; }

        public int openedBy { get; set; }

        public int status { get; set; }

        public AgentInfoDto agent { get; set; }
    }
}