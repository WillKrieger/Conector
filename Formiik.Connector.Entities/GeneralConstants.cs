namespace Formiik.Connector.Entities
{
    public static class GeneralConstants
    {
        #region - accoiunt connection -

        public const string STORAGE_ACCOUNT_NAME = "connectorvanguardia";

        public const string STORAGE_ACCOUNT_KEY = "6jyU5gkeW0ZoK5p6scVs4+BjwSvo9oR4MlWYFo+E9F300ycXWfy2z021OUxY/aNxZQJdRNcG8Z1jj1qWD0MI/g==";

        #endregion
 
        #region - Table storages -
        /// <summary>
        /// Log application events table storage
        /// </summary>
        public const string TS_LOG_APPLICATION_EVENT = "LogApplicationEvent";
        
        /// <summary>
        /// Contains relations between work orders and instance
        /// </summary>
        public const string TS_WORK_ORDERS = "WorkOrders";
        
        /// <summary>
        /// contains rules for transformations
        /// </summary>
        public const string TS_XSLT_REQUIREMENTS_RULES = "TransformRules";

        /// <summary>
        /// Responses from Engine using for create flexible update responses 
        /// </summary>
        public const string TS_FLEXIBLE_UPDATE_ENGINE_RESPONSES = "ResponsesFlexibleUpdateFromEngine";
        
        /// <summary>
        /// Configuration for flexible update request ( Expected requirements )
        /// </summary>
        public const string TS_FLEXIBLE_UPDATE_ENGINE_RESPONSES_CONFIG = "ResponsesFlexibleUpdateFromEngineConfig";

        #endregion
        
        /// <summary>
        /// Name for node in xslt files for custom data mapping
        /// </summary>
        public const string CONNECTOR_DATA_MAPPING_NODE_NAME = "ConnectorDataMapping";
    }
}
