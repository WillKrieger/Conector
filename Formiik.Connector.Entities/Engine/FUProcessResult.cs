using Formiik.Connector.Entities.Engine.Dto;

namespace Formiik.Connector.Entities.Engine
{
    public class FUProcessResult
    {
        public FUProcessResult()
        {
            Successful = false;
            //InstanceId = string.Empty;
        }

        /// <summary>
        /// Id of container that initialize the request
        /// </summary>
        public string ContainerSourceId { get; set; }
        
        /// <summary>
        /// If requirement is success
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Errors generated in partial save http request
        /// </summary>
        public GenericErrorApiEngineResDto PartialSaveError { get; set; }

        /// <summary>
        /// Errors generated in when request process instance
        /// </summary>
        public GenericErrorApiEngineResDto ProcessingError { get; set; }
        
        /// <summary>
        /// Errors from push new comments
        /// </summary>
        public GenericErrorApiEngineResDto NewCommentsErrror { get; set; }
        
        /// <summary>
        /// Errors for confirm comments
        /// </summary>
        public GenericErrorApiEngineResDto ConfirmCommentsErrror { get; set; }
        
    }
}