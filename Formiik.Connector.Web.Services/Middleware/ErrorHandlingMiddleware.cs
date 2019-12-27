using System;
using System.Net;
using System.Threading.Tasks;
using Formiik.Connector.Entities.CustomExceptions;
using Formiik.Connector.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Formiik.Connector.Web.Services.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private const string JSON_RESULT = "application/json";
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string errorId = string.Empty;
            string errorMessage = string.Empty;
            
            var code = HttpStatusCode.InternalServerError;
            
            if (exception is ManagedException)
            {
                code = HttpStatusCode.BadRequest;
                errorMessage = exception.Message;
            }
            else if(exception is ApiUnautorizeException)
            {
                var unAuth = exception as ApiUnautorizeException;

                errorId = ApplicationLogger.LogError(unAuth.Url, unAuth.Message, exception,
                    parameters: new {unAuth.ReqHeaders});
                
                code = HttpStatusCode.Unauthorized;
                errorMessage = $"{exception.Message}. Connector-ErrId: {errorId}";

            }
            else
            {
                errorId = ApplicationLogger.LogError(string.Empty, exception.Message, exception);
                errorMessage = $"Connector-ErrId: {errorId}";
            }
            
            var result = JsonConvert.SerializeObject(new ConnectorErrorDetails()
                {Code = code, Message = errorMessage});
            
            context.Response.ContentType = JSON_RESULT;
            context.Response.StatusCode = (int) code;
            
            return context.Response.WriteAsync(result);
        }
    }
}