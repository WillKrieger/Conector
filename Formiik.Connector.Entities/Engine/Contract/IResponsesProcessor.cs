using System.Collections.Generic;
using System.Threading.Tasks;

namespace Formiik.Connector.Entities.Engine.Contract
{
    public interface IResponsesProcessor
    {
        Task<string> ProcessResponse(Dictionary<string, string> incomeHeaders, string xmlResponse);
    }
}