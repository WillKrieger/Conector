using System.Collections.Generic;
using Formiik.Connector.Entities.Engine.Dto;

namespace Formiik.Connector.Entities.Engine
{
    public class TransformRuleByRequirementStatus
    {
        /// <summary>
        /// Custom status expected
        /// </summary>
        public int ExpectedCustomStatus { get; set; }
        
        /// <summary>
        /// Core status expected
        /// </summary>
        public int ExpecterStatusContainer { get; set; }
        
//        /// <summary>
//        /// Container is at AgentsAssigned in <see cref="IncomeRequirementInfoDto"/>
//        /// </summary>
//        public string ContainerIdForUserAssignment { get; set; }
        
        /// <summary>
        /// List of containers on which the requirement depends
        /// </summary>
        public List<string> ContainersWhomDependOn { get; set; }
    }
}