using System;
using System.Threading.Tasks;

namespace Formiik.Connector.Data
{
    public class MessagesSvc : ServiceBase
    {
        public async Task<string> SendMessage(string clientId, string productId)
        {
            var res = await BackendService.QueueMessageToUserNameAsync(clientId, productId, "system", "juan.perez", "demo", true);
            
            return res;
        }
    }
}