using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Entities.TsEntity
{
    public class TsRequirementTranformRule : TableEntity
    {
        public string RuleId
        {
            get => RowKey;
            set => RowKey = value;
        }

        #region - Formiik -

        public string ClientId { get; set; }
        public string IdWorkOrderType { get; set; }
        
        
        /// <summary>
        /// Form Engine to Formiik
        /// </summary>
        public string FormInFormiik { get; set; }
        
        /// <summary>
        /// If of instance or 
        /// </summary>
        public string SectionId { get; set; }

        /// <summary>
        /// Form Engine to Formiik
        /// </summary>
        public string FormVersionInFormiik { get; set; }

        /// <summary>
        /// Priority for assign workorder to formiik
        /// </summary>
        public int AssignmentPriority { get; set; }

        public string ProductId { get; set; }

        public int HoursAddToExpirationDate { get; set; }

        public int HoursAddToCancellationDate { get; set; }
        
        #endregion

        #region - Engine properties -

        /// <summary>
        /// Definition id from Engine
        /// </summary>
        public string DefinitionId { get; set; }
        
        /// <summary>
        /// If of instance or 
        /// </summary>
        public string ContainerId { get; set; }
        
        /// <summary>
        /// Tenant Id from Engine 
        /// </summary>
        public string TenantId { get; set; }
        
        
        #endregion

        #region - Transformation rule-

        /// <summary>
        /// Xslt for transform data ( Formiik to Engine objects )
        /// </summary>
        public string XsltTransformation { get; set; }
        
        /// <summary>
        /// Remove empty properties
        /// </summary>
        public bool RemoveNullAndEmty { get; set; }
        
        /// <summary>
        /// Information about rule
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Custom status rule
        /// </summary>
        public string RulesApliedToStatusAsJson { get; set; }

        #endregion
        
    }
}