using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.Utils;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.MobileProxy.Transformer
{
    public class EngineToMobileParser
    {
        private const string CLOSE_TAB_FORMEDIT_START = "<FormEditResponse>";
        private const string CLOSE_TAB_FORMEDIT_END = "</FormEditResponse>";
        private const string XPATH_SUB_FORMS = "/*/*";
        private readonly XDocument parametersEngineToFormiik;
        private readonly TsRequirementTranformRule rulesTransform;
        
        private const string FORM_EDIT_RESPONSE_START_KEY ="<FormEditResponse";

        private bool _existComments;
        private const string HAS_COMMENTS_PARAMETER_NAME = "FormiikOrderRejected";
        private const string HAS_COMMENTS_PARAMETER = "TRUE";


        public EngineToMobileParser(IncomeRequirementInfoDto requestEngine, TsRequirementTranformRule transformationRules)
        {
            JObject comments = null;
            _existComments = false;
            
            if (requestEngine.comments != null)
            {
                JsonCommentsCreator creator = new JsonCommentsCreator(requestEngine.values, requestEngine.comments);

                comments = creator.CreateJson();

                if (comments != null && creator.ExistsComments)
                {
                    _existComments = true;
                }
            }

            string json = FormiikGenericParser.SerializeToJson(new {requestEngine.values, comments = comments});

            var addRootToRequest = FormiikGenericParser.NodeJsonToXml(json);

            XDocument xdocumentInput = XDocument.Parse(addRootToRequest.OuterXml);

            parametersEngineToFormiik = xdocumentInput;
            rulesTransform = transformationRules;
        }
 
        public Dictionary<string, string> ToDictionaryValues()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            
            XmlDocument transformEngineToFormiik = ApplyXslt(rulesTransform);
            
            XmlNodeList childNodes = transformEngineToFormiik.SelectNodes(XPATH_SUB_FORMS);

            string xpathCustomMappint = $"//{GeneralConstants.CONNECTOR_DATA_MAPPING_NODE_NAME}";
            
            XmlNode customDataMapping = transformEngineToFormiik.SelectSingleNode(xpathCustomMappint);

            if (customDataMapping != null)
            {
                List<DataMapping> mapOptions = FormiikGenericParser.DeserializeFromJson<List<DataMapping>>(customDataMapping.InnerText);

                foreach (DataMapping mapping in mapOptions)
                {
                    XmlNodeList affectedNodes = transformEngineToFormiik.SelectNodes(mapping.Path);

                    foreach (XmlNode singleNode in affectedNodes)
                    {
                        MapItem item = mapping.Options.FirstOrDefault(p => p.ActualValue == singleNode.InnerText);

                        if (item != null)
                        {
                            singleNode.InnerText = item.NewValue;
                        }
                    }
                }
                
            }
            
            foreach (XmlElement node in childNodes)
            {
                if (node.InnerXml.StartsWith(FORM_EDIT_RESPONSE_START_KEY))
                {
                    string formEditVal = PrepareFormEdit(node.Name, node.InnerXml);

                    if (!string.IsNullOrEmpty(formEditVal))
                    {
                        result.Add(node.Name, formEditVal);
                    }
                }
                else
                {
                    result.Add(node.Name, node.InnerXml);
                }
            }

            if (_existComments)
            {
                result.Add(HAS_COMMENTS_PARAMETER_NAME, HAS_COMMENTS_PARAMETER);
            }

            result.Remove(GeneralConstants.CONNECTOR_DATA_MAPPING_NODE_NAME);
            
            return result;
        }
        
        private string PrepareFormEdit(string nameNode, string formEdit)
        {
            string formEditValues = string.Empty;

            if (!string.IsNullOrEmpty(formEdit))
            {
                XElement doc = XElement.Parse(formEdit);
                
                doc.Descendants().Where(e => string.IsNullOrEmpty(e.Value)).Remove();

                StringBuilder sb = new StringBuilder();

                foreach(var node in doc.Nodes()) {
                    sb.Append(node);
                }
            
                if (sb.Length > 0)
                {
                    string addtagsFormEdit = CloseFormEdit(sb, nameNode);
                    formEditValues = HttpUtility.HtmlEncode(addtagsFormEdit);
                }
            }
            
            return formEditValues;
        }
        
        private static string CloseFormEdit(StringBuilder parameters, string nameField)
        {
            parameters.Insert(0, CLOSE_TAB_FORMEDIT_START);
            parameters.Append(CLOSE_TAB_FORMEDIT_END);
            
            XmlDocument doc = new XmlDocument();
            
            doc.LoadXml(parameters.ToString());

            string parametersString = doc.OuterXml;
            
            return parametersString;
        }
        
        private XmlDocument ApplyXslt(TsRequirementTranformRule rules)
        {
            XDocument newTree = new XDocument();

            try
            {
                using (XmlWriter writer = newTree.CreateWriter())
                {
                    XslCompiledTransform xslt = new XslCompiledTransform();
                    xslt.Load(XmlReader.Create(new StringReader(rules.XsltTransformation)));
                    xslt.Transform(parametersEngineToFormiik.CreateReader(), writer);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"{rules.RuleId}; Invalid XSLT Engine => Formiik {e}");
            }

            XmlDocument doc = new XmlDocument();
            var resultTrans = newTree.ToString();
            doc.LoadXml(resultTrans);

            return doc;
        }
    }
}
