namespace Formiik.Connector.Entities.Engine
{
    public class InstanceInfo
    {
        /// <summary>
        /// Task Id ( formiik: ExternalId)
        /// </summary>
        public string instanceId { get; set; }


        /// <summary>
        /// If of instance type in Engine
        /// </summary>
        public string definitionId { get; set; }
        
        /// <summary>
        /// Tenant Id from Engine 
        /// </summary>
        public string tenantId { get; set; }
    }
}