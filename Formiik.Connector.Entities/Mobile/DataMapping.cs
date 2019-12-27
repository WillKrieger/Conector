using System.Collections.Generic;

namespace Formiik.Connector.Entities.Mobile
{
    public class MapItem
    {
        public string ActualValue { get; set; }

        public string NewValue { get; set; }
    }
        
    public class DataMapping
    {
        public string Path { get; set; }

        public List<MapItem> Options { get; set; }
    }
}