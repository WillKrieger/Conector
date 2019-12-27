using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Emlink.Pitzotl.BackEndPipe.DataContracts;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.Mobile.Dto;
using Newtonsoft.Json;

namespace Formiik.Connector.Data
{
    public class WorkorderSvc : ServiceBase
    {
        public async Task<List<FormiikStatusWorkOrder>> GetWorkOrdersStateByExternalIds(string idClient,
            string externalId)
        {
            var creationResult = await BackendService.GetWorkOrdersStateByExternalIdsAsync(idClient, externalId);

            var orderStatusInFormiik = JsonConvert.DeserializeObject<List<FormiikStatusWorkOrder>>(creationResult);

            return orderStatusInFormiik;
        }

        public async Task<string> AddNewWorkOrderToUserName(NewWorkOrder order)
        {
            int i = 0;

            var orderParameters = new HashTableCompositeType[order.ParametersAsDictionary.Count];

            foreach (var param in order.ParametersAsDictionary)
            {
                orderParameters[i] = new HashTableCompositeType() {Key = param.Key, Value = param.Value};
                i++;
            }

            var creationResult = await BackendService.AddNewWorkOrderToUserNameAsync(
                order.Id,
                order.ClientId,
                order.ProductId,
                order.Type,
                order.Version,
                order.UserName,
                order.Priority,
                order.ExpirationDate,
                order.CancellationDate,
                orderParameters);

            return creationResult;
        }
 
        public async Task<string> UpdateWorkOrdersXmlId(NewWorkOrder order)
        {
            string xmlOfAssignation = ToXml(order);
            
            var creationResult = await BackendService.UpdateWorkOrdersXMLIdAsync(
                order.ClientId,
                order.ProductId,
                xmlOfAssignation);

            return creationResult;
        } 
        
        public async Task<string> UpdateExistsWorkOrdersId(NewWorkOrder order)
        {
            string xmlOfAssignation = ToXml(order);
            
            var creationResult = await BackendService.UpdateExistsWorkOrdersIdAsync(
                order.ClientId,
                order.ProductId,
                xmlOfAssignation);

            return creationResult;
        }

        public async Task<string> CancelWorkOrdersId(CancelWorkOrder order)
        {

            var result = await BackendService.CancelWorkOrderAsync(
                order.Id,
                order.ClientId,
                order.ProductId,
                string.Empty);

            return result;
        }

        private string ToXml(NewWorkOrder infoWorkOrder)
        {
            var doc = new XmlDocument();
            var xmlHead = doc.CreateElement("Coleccion");
            var xmlAux = doc.CreateElement("head");
            xmlHead.AppendChild(xmlAux);
            var xmlNew = doc.CreateElement("NewOrder");
            var xmlAuxNew = doc.CreateElement("Order");
            xmlNew.AppendChild(xmlAuxNew);
            var xmlParam = doc.CreateElement("parametros");

            xmlNew.SetAttribute("id", infoWorkOrder.Id);
            xmlNew.SetAttribute("type", infoWorkOrder.Type);
            xmlNew.SetAttribute("version", infoWorkOrder.Version);
            xmlNew.SetAttribute("userName", infoWorkOrder.UserName);
            xmlNew.SetAttribute("priority", infoWorkOrder.Priority.ToString());
            xmlNew.SetAttribute("expirationDate", infoWorkOrder.ExpirationDate);
            xmlNew.SetAttribute("cancellationDate", infoWorkOrder.CancellationDate);
            
            xmlAux.AppendChild(xmlNew);

            foreach (var item in infoWorkOrder.ParametersAsDictionary)
            {
                var xmlParameterAux = this.CreateParameterElement(doc, item.Key, item.Value);
                xmlParam.AppendChild(xmlParameterAux);
            }

            xmlAuxNew.AppendChild(xmlParam);
            doc.AppendChild(xmlHead);
            var result = doc.InnerXml.Replace("<head>", "\r\n\t");
            result = result.Replace("</head>", "\r\n");
            result = result.Replace("<Order>", "\r\n\t\t");
            result = result.Replace("</Order>", "\r\n\t");
            result = result.Replace("<Par>", "\r\n\t\t\t");
            result = result.Replace("</Par>", string.Empty);
            
            return result;
        }
        
        private XmlElement CreateParameterElement(XmlDocument doc, string key, string value)
        {
            var xmlElemento = doc.CreateElement("parametro");
            var xmlParameterAux = doc.CreateElement("Par");
            xmlParameterAux.AppendChild(xmlElemento);
            xmlElemento.SetAttribute("llave", key);
            xmlElemento.SetAttribute("valor", value);
            return xmlParameterAux;
        }
    }
}