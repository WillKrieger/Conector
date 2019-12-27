using System.Collections.Generic;
using System.Threading.Tasks;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;

namespace Formiik.Connector.Entities.Engine.Contract
{
    public interface IFlexibleUpdateProcessor
    {
        Task<FlexibleUpdateResponseDto> SendRequestToPlatform(Dictionary<string, string> incomeHeaders, FlexibleUpdateRequestDto request);
    }
}