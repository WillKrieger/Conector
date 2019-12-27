using System;
using System.Collections.Generic;
using System.Net;
using Formiik.Connector.Data.RestServices;
using Formiik.Connector.ProcessorTests.TestEntities;
using Xunit;

namespace Formiik.Connector.ProcessorTests.Utils
{
    internal static class LoginUtilsTests
    {
        #region - private methods -
        public static Dictionary<string, string> GetRequestHeaders(string usr, string pwd)
        {
            try
            {
            var formInfor = new Dictionary<string, string>();
            formInfor.Add("client_id", "f966d472-2b92-4ddd-82e6-aec8179c7c03");
            formInfor.Add("password", pwd);
            formInfor.Add("username", usr);
            formInfor.Add("grant_type", "password");
            formInfor.Add("resource", "https://graph.windows.net");
            formInfor.Add("client_secret", "+VFoDurwwxXUK49SCq5xfhIbFznpjXN+SZtndg0alx0=");

            var authResponse = RestServiceCaller.ApiPostForm<AutenticationResultForTests>(
                "https://login.microsoftonline.com/cd03d0b3-7569-435b-9b2d-857c640979de/oauth2/token",
                null,
                formInfor
            ).Result;

            Assert.True(authResponse.StatusCode == HttpStatusCode.OK);

            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", $"Bearer {authResponse.ResponseObject.access_token}");
            
            return headers;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"No se puede autenticar '{usr}', {e.Message}");
            }
        }
        #endregion

        #region - private methods -
        public static Dictionary<string, string> GetRequestHeadersBancoW(string usr, string pwd)
        {
            try
            {
                var formInfor = new Dictionary<string, string>();
                formInfor.Add("client_id", "ae592352-cbc9-452c-bf90-8c909f524d06");
                formInfor.Add("password", pwd);
                formInfor.Add("username", usr);
                formInfor.Add("grant_type", "password");
                formInfor.Add("resource", "https://graph.windows.net");
                formInfor.Add("client_secret", "bFfZ+FHRsvdCjGG9xMGrLtgtNKHiMSudZTqzEw+DbvY=");

                var authResponse = RestServiceCaller.ApiPostForm<AutenticationResultForTests>(
                    "https://login.microsoftonline.com/85cf9832-e665-4950-8d76-257705460e96/oauth2/token",
                    null,
                    formInfor
                ).Result;

                Assert.True(authResponse.StatusCode == HttpStatusCode.OK);

                var headers = new Dictionary<string, string>();
                headers.Add("Authorization", $"Bearer {authResponse.ResponseObject.access_token}");

                return headers;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"No se puede autenticar '{usr}', {e.Message}");
            }
        }
        #endregion
        
        public static Dictionary<string, string> GetRequestHeadersVanguardia(string usr, string pwd)
        {
            try
            {
                var formInfor = new Dictionary<string, string>();
                formInfor.Add("client_id", "2123c13c-93df-465f-ae8f-60eb47649043");
                formInfor.Add("password", pwd);
                formInfor.Add("username", usr);
                formInfor.Add("grant_type", "password");
                formInfor.Add("resource", "https://graph.windows.net");
                formInfor.Add("client_secret", "j1nx2HSjOlXWLrtQsflp82m1dlEViy/iIhTW/JnIEuI=");

                var authResponse = RestServiceCaller.ApiPostForm<AutenticationResultForTests>(
                    "https://login.microsoftonline.com/35412e1e-9e4d-4e46-82f9-6a0985277522/oauth2/token",
                    null,
                    formInfor
                ).Result;

                Assert.True(authResponse.StatusCode == HttpStatusCode.OK);

                var headers = new Dictionary<string, string>();
                headers.Add("Authorization", $"Bearer {authResponse.ResponseObject.access_token}");

                return headers;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"No se puede autenticar '{usr}', {e.Message}");
            }
        }
    }
}