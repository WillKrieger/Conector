using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using Formiik.Connector.Entities.CustomExceptions;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Mobile.Dto.Android;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Processor.MobileProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.EngineProxy.Transformer
{
    public static class MobileToEngineTransformer
    {
        private const string KEY_NAME_BUILDER = "{0}.{1}";
        private const string KEY_ARRAY_BUILDER = "{0}[{1}]";
        private const string START_JSON_KEY = "{";
        private static readonly string[] KeyForCommentValue;

        static MobileToEngineTransformer()
        {
            KeyForCommentValue = new[] {"value"};
        }

        public static TransformResult TransformFlexibleUpdate(FlexibleUpdateRequestDto request, string xsltDoc,
            bool removeNulls,
            out StringBuilder errors)
        {
            errors = new StringBuilder();

            var newValues = new Dictionary<string, object>();

            if (request.InputFields != null)
            {
                foreach (var field in request.InputFields)
                {
                    XmlDocument doc;

                    if (IsFormEditResponse(field.Value, out doc))
                    {
                        object newValue = XmlToObject(doc);
                        newValues.Add(field.Key, newValue);
                    }
                    else if (IsGpsEdit(field.Value, out doc))
                    {
                        object newValue = XmlToObject(doc);
                        newValues.Add(field.Key, newValue);
                    }
                    else
                    {
                        newValues.Add(field.Key, field.Value);
                    }
                }
            }

            var inputAsJson = FormiikGenericParser.SerializeToJson(new {root = newValues});

            XmlDocument inputAsXml = FormiikGenericParser.JsonToXml(inputAsJson);

            TransformResult result = CreateResponse(inputAsXml, xsltDoc, removeNulls, ref errors);

            return result;
        }

        public static TransformResult TransformResponse(string xmlResponse, string xsltDoc, bool removeNulls,
            out StringBuilder errors)
        {
            errors = new StringBuilder();
            XmlDocument response = new XmlDocument();
            response.LoadXml(xmlResponse);
            
            TransformResult result = CreateResponse(response, xsltDoc, removeNulls, ref errors);
            
            return result;
        }

        private static TransformResult CreateResponse(XmlDocument inputAsXml, string xsltDoc,bool removeNulls, ref StringBuilder errors)
        {
            TransformResult result = new TransformResult();
                
            // Get values
            var responseValues = new XmlDocument();
            responseValues.LoadXml(inputAsXml.OuterXml);
            
            XmlNode element = responseValues.FirstChild;
            RemoveComments(element);

            XDocument responseValuesXml = XDocument.Parse(element.OuterXml);

            string responseJson = ApplyXslt(responseValuesXml, xsltDoc);

            result.Values = CreateResponse(responseJson, removeNulls, ref errors);
            
            // Get comments
            var responseComments = new XmlDocument();
            responseComments.LoadXml(inputAsXml.OuterXml);
            
            XmlNode elementComments = responseComments.FirstChild;
            RemoveValues(elementComments);

            XDocument responseCommentsXml = XDocument.Parse(elementComments.OuterXml);

            string commentsJson = ApplyXslt(responseCommentsXml, xsltDoc);

            result = AddComments(result, commentsJson, ref errors);

            MobileToEngineDataMapper.MappingData(result.Values);
                
            return result;
        }
        
        private static void RemoveComments(XmlNode responseXml)
        {
            if (responseXml.HasChildNodes)
            {
                foreach (XmlNode child in responseXml.ChildNodes)
                {
                    RemoveComments(child);
                }
            }
            else
            {
                if (TryGetValueWithComment(responseXml.Value, out ValueInResponseDto valueInResponse))
                {
                    responseXml.Value = valueInResponse.value;
                }
            }
        }
        
        private static void RemoveValues(XmlNode responseXml)
        {
            if (responseXml.HasChildNodes)
            {
                foreach (XmlNode child in responseXml.ChildNodes)
                {
                    RemoveValues(child);
                }
            }
            else
            {
                if (responseXml.Value != null)
                {
                    if (!TryGetValueWithComment(responseXml.Value, out ValueInResponseDto valueInResponse))
                    {
                        try
                        {
                            responseXml.Value = string.Empty;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            string jsonValue = FormiikGenericParser.SerializeToJson(valueInResponse);
                            jsonValue = jsonValue.Replace("\"", "'");
                            responseXml.Value = jsonValue;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                        
                    }
                }
            }
        }
        
        private static bool TryGetValueWithComment(string value, out ValueInResponseDto response)
        {
            bool isValueWithComment = false;
            response = null;
            
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Trim();

                if (value.StartsWith(START_JSON_KEY))
                {
                    bool hasCommentProperties = KeyForCommentValue.All(value.Contains);

                    if (hasCommentProperties)
                    {
                        response = FormiikGenericParser.DeserializeFromJson<ValueInResponseDto>(value);

                        if (response != null)
                        {
                            isValueWithComment = true;  
                        }
                    }    
                }
            }
            
            return isValueWithComment;
        }
        
        #region - FormEdit Transformation-

        private static bool IsFormEditResponse(string valueContent, out XmlDocument doc)
        {
            bool isXml = false;
            doc = null;

            if (!string.IsNullOrEmpty(valueContent))
            {
                if (valueContent.StartsWith("<FormEditResponse"))
                {
                    isXml = true;

                    try
                    {
                        doc = FormiikGenericParser.StringToXml(valueContent);
                    }
                    catch
                    {
                        isXml = false;
                    }
                }
            }

            return isXml;
        }

        private static object XmlToObject(XmlDocument nodeValue)
        {
            string valuesAsString = FormiikGenericParser.XmlToJson(nodeValue);

            var parsed = FormiikGenericParser.DeserializeFromJson<Dictionary<string, object>>(valuesAsString);

            return parsed;
        }

        #endregion

        #region - Gps -

        private static bool IsGpsEdit(string valueContent, out XmlDocument doc)
        {
            bool isXml = false;
            doc = null;

            if (!string.IsNullOrEmpty(valueContent) && valueContent.StartsWith(START_JSON_KEY))
            {
                bool containsGpsTokens = valueContent.Contains("gpsAddress") && valueContent.Contains("gpsLat") &&
                            valueContent.Contains("gpsLng");

                if (containsGpsTokens)
                {
                    isXml = true;

                    try
                    {
                        var jsonObject = FormiikGenericParser.DeserializeFromJson<dynamic>(valueContent);

                        doc = FormiikGenericParser.JsonToXml("{root:" + valueContent + "}");
                    }
                    catch
                    {
                        isXml = false;
                    }
                }
            }

            return isXml;
        }
        #endregion
        
        #region - Xslt transformation -

        private static string ApplyXslt(XDocument inputAsXml, string xsltDoc)
        {
            string value;

            try
            {
                XDocument newTree = new XDocument();

                using (XmlWriter writer = newTree.CreateWriter())
                {
                    XslCompiledTransform xslt = new XslCompiledTransform();
                    xslt.Load(XmlReader.Create(new StringReader(xsltDoc)));

                    xslt.Transform(inputAsXml.CreateReader(), writer);
                }

                value = newTree.Root?.Value;
            }
            catch (Exception e)
            {
                throw new ManagedException(e.Message);
            }

            return value;
        }

        #endregion

        #region -Json Utils- 

        #endregion

        private static JObject CreateResponse(string valuesAsJson, bool removeNulls, ref StringBuilder errors)
        {
            var token = JToken.Parse(valuesAsJson);
            
            if (removeNulls)
            {
                JsonUtils.RemoveNullNodes(token, errors);
            }

            var result = (JObject) token;
            
            return result;
        }
        
        private static TransformResult AddComments(TransformResult transformValues, string valuesAsJson, ref StringBuilder errors)
        {
            JToken token = JToken.Parse(valuesAsJson);
            
            JsonUtils.RemoveNullNodes(token, errors);

            var newComments = new Dictionary<string, string>();
            var resolveComments = new Dictionary<string, string>();

            RebuildComments(token, newComments, resolveComments, ref errors);

            transformValues.NewComments = newComments;
            transformValues.ResolveComments = resolveComments;
            
            return transformValues;
        }

        private static void RebuildComments(JToken info, Dictionary<string, string> newComments, Dictionary<string, string> resolveComments, ref StringBuilder errors, string parent = null)
        {
            if (info == null) return;
            
            if (info is JValue)
            {
                var tokenValue = ((JValue) info).Value;
     
                if (TryGetValueWithComment(tokenValue.ToString(), out ValueInResponseDto response))
                {
                    if (response.comment != null)
                    {
                        if (!string.IsNullOrEmpty(response.comment.text) && !newComments.ContainsKey(parent))
                        {
                            newComments.Add(parent, response.comment.text);
                        }

                        if (!string.IsNullOrEmpty(response.comment.id) && !resolveComments.ContainsKey(parent))
                        {
                            resolveComments.Add(parent, response.comment.id);
                        }    
                    }
                }
            }
            else if (info is JObject)
            {
                foreach (JProperty property in ((JObject)info).Properties())
                {
                    string key = property.Name;
                        
                    if (!string.IsNullOrWhiteSpace(parent))
                    {
                        key = String.Format(KEY_NAME_BUILDER, parent, key);
                    }

                    RebuildComments(property.Value, newComments, resolveComments, ref errors, key);
                }
            }
            else if ((info is JArray) && (parent!=null))
            {
                JArray array = info as JArray;
                int numItems = array.Count;
                for (int i = 0; i < numItems; i++)
                {
                    if ((array[i]!=null) && (array[i] is JObject))
                    {
                        string arrayKey = String.Format(KEY_ARRAY_BUILDER, parent, i);
                        RebuildComments(array[i], newComments, resolveComments, ref errors, arrayKey);
                    }
                    else if (array[i] is JValue)
                    {
                        var tokenValue = ((JValue) array[i]).Value;
     
                        string arrayKey = String.Format(KEY_ARRAY_BUILDER, parent, i);
                            
                        if (TryGetValueWithComment(tokenValue.ToString(), out ValueInResponseDto response))
                        {
                            if (response.comment != null)
                            {
                                // cuando on arreglos sólo se toma en cuenta el primer comentario
                                if (!string.IsNullOrEmpty(response.comment.text) && !newComments.ContainsKey(parent))
                                {
                                    newComments.Add(parent, response.comment.text);
                                }
//                                    else
//                                    {
//                                        errors.Append(
//                                            $"Comentario descartado {arrayKey}, ya exite comentario en: {parent}: ");
//                                    }

                                if (!string.IsNullOrEmpty(response.comment.id) && !resolveComments.ContainsKey(arrayKey))
                                {
                                    resolveComments.Add(arrayKey, response.comment.id);
                                }    
                            }
                        }
                    }
                }
            }
        }
    }
}