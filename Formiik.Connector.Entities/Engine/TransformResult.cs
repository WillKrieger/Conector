using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Entities.Engine
{
    public class TransformResult
    {
        public TransformResult()
        {
            NewComments = new Dictionary<string, string>();
            ResolveComments = new Dictionary<string, string>();
        }

        public JObject Values { get; set; }

        public Dictionary<string, string> NewComments { get; set; }

        public Dictionary<string, string> ResolveComments { get; set; }
    }
}