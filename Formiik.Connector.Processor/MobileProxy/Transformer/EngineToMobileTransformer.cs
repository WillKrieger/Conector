using System;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.TsEntity;

namespace Formiik.Connector.Processor.MobileProxy.Transformer
{
    public static class EngineToMobileTransformer
    {
        public static NewWorkOrder TransformToNewWorkOrder(IncomeRequirementInfoDto requestEngine,
            TsRequirementTranformRule xsltDefTransformFormiik)
        {
            var orderInFormiik = new NewWorkOrder();

            orderInFormiik.Id = requestEngine.instanceId;
            orderInFormiik.UserName = requestEngine.agentUsername;
            orderInFormiik.ContainerId = requestEngine.containerId;
            orderInFormiik.ClientId = xsltDefTransformFormiik.ClientId;

            orderInFormiik.Type = xsltDefTransformFormiik.FormInFormiik;
            orderInFormiik.Version = xsltDefTransformFormiik.FormVersionInFormiik;
            orderInFormiik.Priority = xsltDefTransformFormiik.AssignmentPriority;
            orderInFormiik.ProductId = xsltDefTransformFormiik.ProductId;
            orderInFormiik.ExpirationDate = DateTime.UtcNow.AddHours(xsltDefTransformFormiik.HoursAddToExpirationDate).ToString(FormiikConstants.INPUT_DATE_FORMAT);
            orderInFormiik.CancellationDate =
                DateTime.UtcNow.AddHours(xsltDefTransformFormiik.HoursAddToExpirationDate).ToString(FormiikConstants.INPUT_DATE_FORMAT);

            var engineToFormiikParser =
                new EngineToMobileParser(requestEngine, xsltDefTransformFormiik);

            orderInFormiik.ParametersAsDictionary = engineToFormiikParser.ToDictionaryValues();
            
            return orderInFormiik;
        }
    }
}