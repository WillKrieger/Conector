using System.Net;

namespace Formiik.Connector.Entities.CustomExceptions
{
    public class ConnectorErrorDetails
    {
        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }
    }
}