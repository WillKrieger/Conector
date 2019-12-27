using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Formiik.Connector.Data.RestServices;
using Formiik.Connector.Entities.CustomExceptions;
using Formiik.Connector.Entities.Engine.Dto;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.Utils
{    
    public static class RestServiceWrapper
    {
        private const string UNKNOW_ERROR_API = "Unknow API error response: {0}";
        private const int INTERNAL_STATUS_SUCCESS = 0;
        
        /// <summary>
        /// Call api using POST verb
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="data"></param>
        /// <param name="httpCodeExpected"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ApiEngineCallException"></exception>
        /// <returns></returns>
        public static async Task<T> ApiPost<T>(
            string url,
            Dictionary<string, string> headers,
            object data,
            HttpStatusCode httpCodeExpected = HttpStatusCode.OK)
        {
            WebClientResponse<T> response = await RestServiceCaller.ApiPost<T>(url, headers, data);

            GenerateExceptionIfExists(url, response, httpCodeExpected, headers);

            return response.ResponseObject;
        }

        /// <summary>
        /// Call api Using Http PUT verb 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="data"></param>
        /// <param name="httpCodeExpected"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ApiEngineCallException"></exception>
        /// <returns></returns>
        public static async Task<T> ApiPut<T>(
            string url,
            Dictionary<string, string> headers,
            object data,
            HttpStatusCode httpCodeExpected = HttpStatusCode.OK)
        {
            WebClientResponse<T> response = await RestServiceCaller.ApiPut<T>(url, headers, data);

            GenerateExceptionIfExists(url, response, httpCodeExpected, headers);

            return response.ResponseObject;
        }
        
        public static async Task<GenericApiEngineResDto> SendHttpPutRequest(
            string url, 
            Dictionary<string, string> headers,
            object data,
            HttpStatusCode httpCodeExpected = HttpStatusCode.OK)
        {
            WebClientResponse<GenericApiEngineResDto> response = await RestServiceCaller.ApiPut<GenericApiEngineResDto>(url, headers, data);

            GenerateExceptionIfExists(url, response, httpCodeExpected, headers);

            if (response.ResponseObject.status != INTERNAL_STATUS_SUCCESS)
            {
                throw new ApiEngineCallException(url, response.StatusCode, response.ResponseContent);
            }

            return response.ResponseObject;
        }
        
        public static async Task<T> ApiGet<T>(
            string url,
            Dictionary<string, string> headers,
            Dictionary<string, string> queryString = null,
            HttpStatusCode httpCodeExpected = HttpStatusCode.OK)
        {
            WebClientResponse<T> response = await RestServiceCaller.ApiGet<T>(url, headers, queryString);

            GenerateExceptionIfExists(url, response, httpCodeExpected, headers);

            return response.ResponseObject;
        }

        private static void GenerateExceptionIfExists<T>(string url, WebClientResponse<T> response, HttpStatusCode httpCodeExpected, Dictionary<string, string> headers)
        {
            if (response.Exception != null)
            {
                throw response.Exception;
            }

            if (response.StatusCode != httpCodeExpected)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ApiUnautorizeException($"Engine: {response.ResponseContent}", url, headers);
                }
                
                throw new ApiEngineCallException(url, response.StatusCode, response.ResponseContent);
            }
        }
        
        public static GenericErrorApiEngineResDto ExtractHttpErrorDetails(string responseContent)
        {
            GenericErrorApiEngineResDto genericError = null;

            if (!string.IsNullOrEmpty(responseContent))
            {
                genericError = FormiikGenericParser.DeserializeFromJson<GenericErrorApiEngineResDto>(responseContent);

                if (genericError == null)
                {
                    throw new ManagedException(string.Format(UNKNOW_ERROR_API, responseContent));
                }

                var errorsJson = FormiikGenericParser.DeserializeFromJson<JObject>(genericError.error);

                if (errorsJson == null)
                {
                    throw new ManagedException(string.Format(UNKNOW_ERROR_API, responseContent));
                }

                genericError.ErrorList = new Dictionary<string, string>();

                foreach (var errorItem in errorsJson)
                {
                    if (!genericError.ErrorList.ContainsKey(errorItem.Key))
                    {
                        genericError.ErrorList.Add(errorItem.Key, errorItem.Value.ToString());
                    }
                }
            }

            return genericError;
        }
    }
}