using System.Threading.Tasks;
using Formiik.Connector.Entities.Engine.Dto;

namespace Formiik.Connector.Entities.Mobile.Contract
{
    public interface IRequirementProcessor
    {
        Task ProcessRequirementReceived(IncomeRequirementInfoDto request);
        Task ProcessInstanceCancellation(IncomeInstanceCancelledDto request);
    }
}