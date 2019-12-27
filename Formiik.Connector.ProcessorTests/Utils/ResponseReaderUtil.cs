using System;
using System.Xml;

namespace Formiik.Connector.ProcessorTests.Utils
{
    public static class ResponseReaderUtil
    {
        public static string GetSection(string xmlResponseFilePath, string secctionName)
        {
            string fullResponse = FileUtil.ReadContentFromResource(xmlResponseFilePath);
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(fullResponse);
            XmlNode node = doc.SelectSingleNode($"/*/*/{secctionName}");

            if (node == null)
            {
                throw new InvalidOperationException($"Section '{secctionName}' not found in response");
            }
            
            string xmlNode = $"<root>{node.InnerXml}</root>";
            
            return xmlNode;
        }
    }
}