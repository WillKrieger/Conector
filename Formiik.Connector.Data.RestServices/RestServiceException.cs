using System;

namespace Formiik.Connector.Data.RestServices
{
    public class RestServiceException : Exception
    {
        public RestServiceException(string message, string responseText)
            : base(message)
        {
            this.Data["ServiceResult"] = responseText;
        }

        public RestServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}