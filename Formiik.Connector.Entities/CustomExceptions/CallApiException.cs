using System;

namespace Formiik.Connector.Entities.CustomExceptions
{
    public class CallApiException : Exception
    {
        public CallApiException(string message) : base(message)
        {

        }

        public CallApiException(string message, Exception innerEx) : base(message, innerEx)
        {
        }
    }
}