namespace Formiik.Connector.Entities.Engine
{
    public class ApiEngineConfiguration
    {
        public string AuthorizationHeader { get; set; }
        public string CreateInstancesUrl { get; set; }
        public string PartialSaveRequirementUrl { get; set; }
        public string ProcessRequirementUrl { get; set; }
        public string GetRequirementByStatusUrl { get; set; }
        public string GetRequirementUrl { get; set; }
        public string NewCommentsUrl { get; set; }
        public string ResolveCommentsUrl { get; set; }
        public string GetRequirementAltUrl { get; set; }

        public string HeaderSuscriptionKey { get; set; }
        public string HeaderSuscriptionValue { get; set; }

    }
}
