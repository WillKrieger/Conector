using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Formiik.Connector.Web.Services.CustomExtenssions
{
    public static class HttpRequestExtensions
    {
        private static readonly Dictionary<string, string> SpecialChars;

        static HttpRequestExtensions()
        {
            SpecialChars = new Dictionary<string, string>();
            SpecialChars.Add("\\u00c0", "À");
            SpecialChars.Add("\\u00c1", "Á");
            SpecialChars.Add("\\u00c2", "Â");
            SpecialChars.Add("\\u00c3", "Ã");
            SpecialChars.Add("\\u00c4", "Ä");
            SpecialChars.Add("\\u00c5", "Å");
            SpecialChars.Add("\\u00c6", "Æ");
            SpecialChars.Add("\\u00c7", "Ç");
            SpecialChars.Add("\\u00c8", "È");
            SpecialChars.Add("\\u00c9", "É");
            SpecialChars.Add("\\u00ca", "Ê");
            SpecialChars.Add("\\u00cb", "Ë");
            SpecialChars.Add("\\u00cc", "Ì");
            SpecialChars.Add("\\u00cd", "Í");
            SpecialChars.Add("\\u00ce", "Î");
            SpecialChars.Add("\\u00cf", "Ï");
            SpecialChars.Add("\\u00d1", "Ñ");
            SpecialChars.Add("\\u00d2", "Ò");
            SpecialChars.Add("\\u00d3", "Ó");
            SpecialChars.Add("\\u00d4", "Ô");
            SpecialChars.Add("\\u00d5", "Õ");
            SpecialChars.Add("\\u00d6", "Ö");
            SpecialChars.Add("\\u00d8", "Ø");
            SpecialChars.Add("\\u00d9", "Ù");
            SpecialChars.Add("\\u00da", "Ú");
            SpecialChars.Add("\\u00db", "Û");
            SpecialChars.Add("\\u00dc", "Ü");
            SpecialChars.Add("\\u00dd", "Ý");
            SpecialChars.Add("\\u00df", "ß");
            SpecialChars.Add("\\u00e0", "à");
            SpecialChars.Add("\\u00e1", "á");
            SpecialChars.Add("\\u00e2", "â");
            SpecialChars.Add("\\u00e3", "ã");
            SpecialChars.Add("\\u00e4", "ä");
            SpecialChars.Add("\\u00e5", "å");
            SpecialChars.Add("\\u00e6", "æ");
            SpecialChars.Add("\\u00e7", "ç");
            SpecialChars.Add("\\u00e8", "è");
            SpecialChars.Add("\\u00e9", "é");
            SpecialChars.Add("\\u00ea", "ê");
            SpecialChars.Add("\\u00eb", "ë");
            SpecialChars.Add("\\u00ec", "ì");
            SpecialChars.Add("\\u00ed", "í");
            SpecialChars.Add("\\u00ee", "î");
            SpecialChars.Add("\\u00ef", "ï");
            SpecialChars.Add("\\u00f0", "ð");
            SpecialChars.Add("\\u00f1", "ñ");
            SpecialChars.Add("\\u00f2", "ò");
            SpecialChars.Add("\\u00f3", "ó");
            SpecialChars.Add("\\u00f4", "ô");
            SpecialChars.Add("\\u00f5", "õ");
            SpecialChars.Add("\\u00f6", "ö");
            SpecialChars.Add("\\u00f8", "ø");
            SpecialChars.Add("\\u00f9", "ù");
            SpecialChars.Add("\\u00fa", "ú");
            SpecialChars.Add("\\u00fb", "û");
            SpecialChars.Add("\\u00fc", "ü");
            SpecialChars.Add("\\u00fd", "ý");
            SpecialChars.Add("\\u00ff", "ÿ");
        }
            
        
        /// <summary>
        /// Retrieve the raw body as a string from the Request.Body stream
        /// </summary>
        /// <param name="request">Request instance to apply to</param>
        /// <param name="encoding">Optional - Encoding, defaults to UTF8</param>
        /// <returns></returns>
        public static async Task<T> GetRawBodyAsync<T>(this HttpRequest request, Encoding encoding = null)
            where T : new()
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            string inputText;

            using (StreamReader reader = new StreamReader(request.Body, encoding))
            {
                inputText = await reader.ReadToEndAsync();
            }

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                inputText = ReplaceAccents(inputText);
            }

            T outputResult = default(T);

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                outputResult = JsonConvert.DeserializeObject<T>(inputText);
            }

            return outputResult;
        }

        public static async Task<string> GetRawBodyAsync(this HttpRequest request, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            string inputText;

            using (StreamReader reader = new StreamReader(request.Body, encoding))
            {
                inputText = await reader.ReadToEndAsync();
            }
            
            if (!string.IsNullOrWhiteSpace(inputText))
            {
                inputText = ReplaceAccents(inputText);
            }

            return inputText;
        }

        public static Dictionary<string, string> GetHeaders(this HttpRequest request)
        {
            var headers = new Dictionary<string, string>();

            if (request.Headers != null)
            {
                foreach (var header in request.Headers)
                {
                    if (!headers.ContainsKey(header.Key))
                    {
                        headers.Add(header.Key, header.Value);
                    }
                }
            }

            return headers;
        }

        private static string ReplaceAccents(string text)
        {
            StringBuilder data = new StringBuilder(text);

            foreach (var special in SpecialChars)
            {
                data.Replace(special.Key, special.Value);
            }

            return data.ToString();
        }
    }
}