using System;
using System.Text;
using Newtonsoft.Json;

namespace Formiik.Connector.Logging.Entity
{
    public class LoggerUtilities
    {
        internal static string SerializeParameters(params object[] parameters)
        {
            string serializeParameters = string.Empty;
            var functionParameter = new StringBuilder();

            if (parameters == null)
            {
                serializeParameters = string.Empty;
            }

            foreach (var parameter in parameters)
            {
                if (functionParameter.Length > 1)
                {
                    functionParameter.Append("|");
                }

                functionParameter.Append(SerializeAditionalData(parameter));
            }

            serializeParameters = functionParameter.ToString();

            return serializeParameters;
        }

        internal static string SerializeAditionalData<T>(T entity)
        {
            string serialized = string.Empty;

            try
            {
                serialized = JsonConvert.SerializeObject(entity);

            }
            catch (Exception exception)
            {
                serialized = "serialization parameters failed: " + exception.Message;
            }

            return serialized;
        }

        internal static void GetDataFromException(Exception exception, ref int nivelCount, ref StringBuilder textSerialize)
        {
            if (nivelCount < 1)
            {
                textSerialize.AppendFormat("Exception{0}[Message:{1}, StackTrace:{2}]", nivelCount, exception.Message, exception.StackTrace);
            }
            else
            {
                textSerialize.AppendFormat("Exception{0}[Message:{1}]", nivelCount, exception.Message);
            }

            if (exception.InnerException == null)
            {
                return;
            }

            nivelCount++;

            GetDataFromException(exception.InnerException, ref nivelCount, ref textSerialize);
        }
    }
}
