using System;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Formiik.Connector.Processor.Utils
{
    public static class FormiikGenericParser
    {

        //        public static T ConvertFromString<T>(string input) where T : struct
        //        {
        //            var converter = TypeDescriptor.GetConverter(typeof(T));
        //
        //            if (!string.IsNullOrEmpty(input))
        //            {
        //                var convertFromString = converter.ConvertFromString(input);
        //
        //                if (convertFromString != null)
        //                {
        //                    return (T)convertFromString;
        //                }
        //            }
        //
        //            return default(T);
        //        }

        //        public static DateTime DateFromstring(string name, string value)
        //        {
        //            DateTime dateValue;
        //
        //            try
        //            {
        //                dateValue = DateTime.Parse(value);
        //            }
        //            catch
        //            {
        //                throw new InvalidCastException(string.Format("{0} es inválido", name));
        //            }
        //
        //            return dateValue;
        //        }
        //
        //        public static DateTime DateFromstring(string name, string value, string format)
        //        {
        //            try
        //            {
        //                return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
        //            }
        //            catch
        //            {
        //                throw new InvalidCastException(string.Format("{0} es inválido, tipo de dato incorrecto, debe estar en formato {1}", name, format));
        //            }
        //        }

        //        public static T ConvertFromString<T>(string variableName, string input) where T : struct
        //        {
        //            if (string.IsNullOrEmpty(input))
        //            {
        //                throw new InvalidCastException(string.Format("No se le ha asignado valor a: {0}", variableName));
        //            }
        //
        //            var converter = TypeDescriptor.GetConverter(typeof(T));
        //
        //            try
        //            {   
        //                var convertFromString = converter.ConvertFromString(input);
        //
        //                if (convertFromString != null)
        //                {
        //                    return (T)convertFromString;
        //                }
        //                
        //                return default(T);
        //            }
        //            catch (Exception exception)
        //            {
        //                throw new InvalidCastException(string.Format("({0}) Tipo de dato inválido.", variableName), exception);
        //            }
        //        }

        public static XmlDocument NodeJsonToXml(string json)
        {
            return JsonConvert.DeserializeXmlNode(json, "Root");
        }

        public static string XmlToJson(XmlDocument xml)
        {
            return JsonConvert.SerializeXmlNode(xml);
        }

        public static XmlDocument JsonToXml(string json)
        {
            return JsonConvert.DeserializeXmlNode(json);
        }

        public static int EnumToInt(Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
        
        public static XmlDocument StringToXml(string xmlAsString)
        {
            var resut = new XmlDocument();
            resut.LoadXml(xmlAsString);
            return resut;
        }

        /// <summary>
        /// Serializa ún objeto usando Newtonsoft.Json, usar de preferencia este método en lugar de SerializeToJson
        /// </summary>
        /// <typeparam name="T">Tipo de dato a serializar</typeparam>
        /// <param name="entity">Entidad a serializar en json</param>
        /// <param name="format">Formato del json</param>
        /// <returns>Objeto en json</returns>
        public static string SerializeToJson<T>(T entity, Formatting format = Formatting.None)
        {
            return JsonConvert.SerializeObject(entity, format);
        }
        
        /// <summary>
        /// Desserializa un objeto
        /// </summary>
        /// <typeparam name="T">Tipo de objeto esperado</typeparam>
        /// <param name="jsonEntity">string que representa al objeto JSON</param>
        /// <returns>Objeto tipado</returns>
        public static T DeserializeFromJson<T>(string jsonEntity)
        {
            return JsonConvert.DeserializeObject<T>(jsonEntity);
        }
    }
}