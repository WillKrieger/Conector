using System;

namespace Formiik.Connector.ProcessorTests.TestEntities
{
    public class TestEntityInfo
    {   
        public string ResourceFolder { get; set; }

        #region - Engine Info-

        public string EngineTenantId { get; set; }
        
        public string DefinitionId { get; set; }
        
        public string ContanierId { get; set; }
        
        public string RequirementExampleFileName { get; set; }
        
        public string XsltEngineToFormiikFileName { get; set; }

        public string XsltEngineToFormiikDescription { get; set; }
        
        #endregion
        
        #region - Formiik Mobile Info -

        public string FormiikClientId { get; set; }
        
        public string FormName { get; set; }

        public Guid IdWorkOrderType { get; set; }
        
        public string SectionId { get; set; }

        public string FormVersion { get; set; }

        public int AssignmentPriority { get; set; }

        public string ProductId { get; set; }

        public int HoursAddToExpirationDate { get; set; }

        public int HoursAddToCancellationDate { get; set; }
        
        public string XsltFormiikToEngineFileName { get; set; }
        
        public string XsltFormiikToEngineDescription { get; set; }
        
        public string FlexibleUpdateExampleFileName { get; set; }
        
        #endregion
    }
}