namespace Formiik.Connector.Data
{
    public abstract class ServiceBase
    {
        protected readonly IBackEnd BackendService;

        protected ServiceBase()
        {
            var endPointConfig = new BackEndClient.EndpointConfiguration();
            
            BackendService = new BackEndClient(endPointConfig);
        }
    }
}