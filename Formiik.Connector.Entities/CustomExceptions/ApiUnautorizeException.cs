using System;
using System.Collections.Generic;

namespace Formiik.Connector.Entities.CustomExceptions
{
    public class ApiUnautorizeException : Exception
    {
        public Dictionary<string, string> ReqHeaders { get; }

        public string Url { get; }
        
        public ApiUnautorizeException(string message, string url, Dictionary<string, string> headers) : base(message)
        {
            Url = url;
            ReqHeaders = headers;
        }
    }
}