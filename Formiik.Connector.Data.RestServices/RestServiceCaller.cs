using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Formiik.Connector.Data.RestServices
{
    public static class RestServiceCaller
    {
        private const string UNEABLE_TO_GET_RESPONSE_ERROR = "Unable to get response from {0}";
        
        private const string APPLICATION_REQUEST_TYPE_JSON = "application/json";
        
        private const string DES_SERIALIZATION_EXCEPTION = "Cannot interpretation api response";

        #region - Post -

        public static async Task<WebClientResponse<T>> ApiPost<T>(string url, Dictionary<string, string> headers,
            object data)
        {
            var response = new WebClientResponse<T>();

            try
            {
                var dataAsJson = JsonConvert.SerializeObject(data);

                using (HttpClient client = CreateHttpClient(headers))
                {
                    StringContent stringContent = new StringContent(dataAsJson, Encoding.UTF8, APPLICATION_REQUEST_TYPE_JSON);

                    HttpResponseMessage requestResult = await client.PostAsync(url, stringContent);

                    string responseContent = await requestResult.Content.ReadAsStringAsync();

                    response.StatusCode = requestResult.StatusCode;
                    response.ResponseContent = responseContent;

                    if (requestResult.StatusCode == HttpStatusCode.OK)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(responseContent))
                            {
                                response.ResponseObject = JsonConvert.DeserializeObject<T>(responseContent);
                            }
                        }
                        catch (Exception serException)
                        {
                            response.Exception = new RestServiceException(DES_SERIALIZATION_EXCEPTION, serException);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = string.Format(UNEABLE_TO_GET_RESPONSE_ERROR, url);

                response.Exception = new RestServiceException(error, ex);
            }

            return response;
        }


        public static async Task<WebClientResponse<T>> ApiPostForm<T>(string url, Dictionary<string, string> headers,
            IEnumerable<KeyValuePair<string, string>> postData)
        {
            var response = new WebClientResponse<T>();

            try
            {
                using (HttpClient client = CreateHttpClient(headers))
                {
                    using (var content = new FormUrlEncodedContent(postData))
                    {
                        HttpResponseMessage requestResult = await client.PostAsync(url, content);

                        string responseContent = await requestResult.Content.ReadAsStringAsync();

                        response.StatusCode = requestResult.StatusCode;
                        response.ResponseContent = responseContent;

                        if (requestResult.StatusCode == HttpStatusCode.OK)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(responseContent))
                                {
                                    response.ResponseObject = JsonConvert.DeserializeObject<T>(responseContent);
                                }
                            }
                            catch (Exception serException)
                            {
                                response.Exception = new RestServiceException(DES_SERIALIZATION_EXCEPTION, serException);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = string.Format(UNEABLE_TO_GET_RESPONSE_ERROR, url);

                response.Exception = new RestServiceException(error, ex);
            }

            return response;
        }

        public static async Task<WebClientResponse<T>> ApiPut<T>(string url, Dictionary<string, string> headers,
            object data)
        {
            var response = new WebClientResponse<T>();

            try
            {
                var dataAsJson = JsonConvert.SerializeObject(data);

                using (HttpClient client = CreateHttpClient(headers))
                {
                    StringContent stringContent =
                        new StringContent(dataAsJson, Encoding.UTF8, APPLICATION_REQUEST_TYPE_JSON);

                    HttpResponseMessage requestResult = await client.PutAsync(url, stringContent);

                    string responseContent = await requestResult.Content.ReadAsStringAsync();

                    response.StatusCode = requestResult.StatusCode;
                    response.ResponseContent = responseContent;

                    if (requestResult.StatusCode == HttpStatusCode.OK)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(responseContent))
                            {
                                response.ResponseObject = JsonConvert.DeserializeObject<T>(responseContent);
                            }
                        }
                        catch (Exception serException)
                        {
                            response.Exception = new RestServiceException(DES_SERIALIZATION_EXCEPTION, serException);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = string.Format(UNEABLE_TO_GET_RESPONSE_ERROR, url);

                response.Exception = new RestServiceException(error, ex);
            }

            return response;
        }

        #endregion

        #region - Get -

        public static async Task<WebClientResponse<T>> ApiGet<T>(string url, Dictionary<string, string> headers,
            Dictionary<string, string> querystring = null)
        {
            var response = new WebClientResponse<T>();

            try
            {
                var query = new StringBuilder();

                var urlToReq = new Uri(url);
                
                if (querystring != null)
                {
                    if (string.IsNullOrEmpty(urlToReq.Query))
                    {
                        query.Append("?");
                    }
                    else
                    {
                        query.Append("&");
                    }
                    
                    foreach (var item in querystring)
                    {
                        query.AppendFormat($"{item.Key}={item.Value}&");
                    }
                }

                url = $"{urlToReq.AbsoluteUri}{query}";

                using (HttpClient client = CreateHttpClient(headers))
                {
                    HttpResponseMessage requestResult = await client.GetAsync(url);

                    string responseContent = await requestResult.Content.ReadAsStringAsync();

                    response.StatusCode = requestResult.StatusCode;
                    response.ResponseContent = responseContent;

                    if (requestResult.StatusCode == HttpStatusCode.OK)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(responseContent))
                            {
                                response.ResponseObject = JsonConvert.DeserializeObject<T>(responseContent);
                            }
                        }
                        catch (Exception serException)
                        {
                            response.Exception = new RestServiceException(DES_SERIALIZATION_EXCEPTION, serException);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = string.Format(UNEABLE_TO_GET_RESPONSE_ERROR, url);

                response.Exception = new RestServiceException(error, ex);
            }

            return response;
        }

        #endregion

        private static HttpClient CreateHttpClient(Dictionary<string, string> headers)
        {
            var client = new HttpClient();

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            return client;
        }
    }
}