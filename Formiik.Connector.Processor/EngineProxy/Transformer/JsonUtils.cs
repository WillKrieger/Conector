using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.EngineProxy.Transformer
{
    internal static class JsonUtils
    {
        public static bool IsNUllOrEmpty(JToken val)
        {
            var tokenValue = ((JValue) val).Value;

            bool isNullOrEmpty = (tokenValue == null || string.IsNullOrWhiteSpace(tokenValue.ToString()));

            return isNullOrEmpty;
        }
        
        public static void RemoveNullNodes(JToken root, StringBuilder errors)
        {
            try
            {
                if (root is JValue)
                {
                    if (IsNUllOrEmpty(root))
                    {
                        root.Parent.Remove();
                    }
                }
                else if (root is JArray)
                {
                    try
                    {
                        var nodeList = ((JArray) root).ToList();

                        bool isSimpleValue = true;
                        bool arrayIsEmpty = true;

                        foreach (var val in nodeList)
                        {
                            if (val is JValue)
                            {
                                if (!IsNUllOrEmpty(val))
                                {
                                    arrayIsEmpty = false;
                                }
                            }
                            else
                            {
                                isSimpleValue = false;
                            }
                        }

                        if (isSimpleValue)
                        {
                            if (arrayIsEmpty)
                            {
                                root.Parent.Remove();
                            }
                        }
                        else
                        {
                            ((JArray) root).ToList().ForEach(n => RemoveNullNodes(n, errors));

                            if (!(((JArray) root)).HasValues)
                            {
                                root.Parent.Remove();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ExtractErrror(root, e, errors);
                    }
                }
                else if (root is JProperty)
                {
                    RemoveNullNodes(((JProperty) root).Value, errors);
                }
                else
                {
                    try
                    {
                        var children = ((JObject) root).Properties().ToList();
                        children.ForEach(n => RemoveNullNodes(n, errors));

                        if (!((JObject) root).HasValues)
                        {
                            if (((JObject) root).Parent is JArray)
                            {
                                ((JArray) root.Parent).Where(x => !x.HasValues).ToList().ForEach(n => n.Remove());
                            }
                            else
                            {
                                if (root.Parent != null)
                                {
                                    var propertyParent = ((JObject) root).Parent;
                                    while (!(propertyParent is JProperty))
                                    {
                                        propertyParent = propertyParent.Parent;
                                    }

                                    propertyParent.Remove();    
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ExtractErrror(root, e, errors);
                    }
                }
            }
            catch (Exception e)
            {
                ExtractErrror(root, e, errors);
            }
        }

        public static void ExtractErrror(JToken root, Exception e, StringBuilder errors)
        {
            if (root.Parent != null)
            {
                errors.AppendLine(root.Parent.Parent != null
                    ? $"{root.Parent.Parent}.{root.Parent}:{e.Message}"
                    : $"{root.Parent}:{e.Message}");
            }
            else
            {
                errors.AppendLine($"{e.Message}");    
            }
        }

    }
}