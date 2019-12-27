using System;
using System.Net;

namespace Formiik.Connector.Data.RestServices
{
    public class WebClientResponse<T>
    {
        /// <summary>
        /// Error en el llamado
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Respuesta regresada por el cliente
        /// </summary>
        public string ResponseContent { get; set; }

        public T ResponseObject { get; set; }
        
        /// <summary>
        /// Estatus http
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}