using System;
using System.Net;

namespace Formiik.Connector.Entities.CustomExceptions
{
    public class ApiEngineCallException : Exception
    {
        public string Url { get; }

        public HttpStatusCode HttpCode { get; }

        public string ResponseContent { get; }

        public ApiEngineCallException(string url, HttpStatusCode httpCode, string content) : base(httpCode.ToString())
        {
            Url = url;

            HttpCode = httpCode;

            ResponseContent = content;
        }

        public override string ToString()
        {
            return $"{HttpCode}: {Url}";
        }
    }
}