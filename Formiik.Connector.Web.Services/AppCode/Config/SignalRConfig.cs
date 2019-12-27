namespace Formiik.Connector.Web.Services.AppCode.Config
{
    public class SignalRConfig
    {
        public string Url { get; set; }

        public string ApiKey { get; set; }

        public string Channel { get; set; }
        public string InstanceCreationFinishedMethod { get; set; }
        public string InstanceProcessingFinishedMethod { get; set; }
        public string InstanceCancelledMethod { get; set; }

    }
}