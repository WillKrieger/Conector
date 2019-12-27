using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Entities.TsEntity
{
    public class TsRequirementDependenciesRule : TableEntity
    {
        public string ClientId
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public string RuleId
        {
            get => RowKey;
            set => RowKey = value;
        }
        
        /// <summary>
        /// Status esperado
        /// </summary>
        public int ExpectedStatus { get; set; }
        
        /// <summary>
        /// Container is at AgentsAssigned in <see cref="IncomeRequirementInfoDto"/>
        /// </summary>
        public string ContainerIdExpectedForSpecificUser { get; set; }
        
        /// <summary>
        /// List of containers on which the requirement depends
        /// </summary>
        public string ContainersWhomDependOn { get; set; }

        public List<string> Containers { get; set; }
    }
}