using System;
using System.Threading.Tasks;
using Formiik.Connector.Logging.Entity;

namespace Formiik.Connector.Logging.Persistance
{
    internal interface IEventLogRepository
    {
        Task WriteEvent(TSApplicationEvent applicationEvent);
    }
}
