using System.Collections.Generic;
using System.Linq;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Processor.EngineProxy.Transformer;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.MobileProxy.Transformer
{
    public static class MobileToEngineDataMapper
    {
        public static void MappingData(JToken token)
        {
            JToken dataMapping = token[GeneralConstants.CONNECTOR_DATA_MAPPING_NODE_NAME];

            if (dataMapping != null)
            {
                List<DataMapping> mapOptions = dataMapping.ToObject<List<DataMapping>>();

                foreach (DataMapping map in mapOptions)
                {
                    JToken replaceItem = token.SelectToken(map.Path);

                    if (!JsonUtils.IsNUllOrEmpty(replaceItem))
                    {
                        JValue val = ((JValue) replaceItem);
                        
                        string actualValue = val.Value.ToString();  
                        
                        if (!string.IsNullOrEmpty(actualValue))
                        {
                            var mapV = map.Options.FirstOrDefault(p => p.ActualValue == actualValue);

                            val.Value = mapV.NewValue;
                        }
                    }
                }
                
                dataMapping.Parent.Remove();
            }
        }
    }
}