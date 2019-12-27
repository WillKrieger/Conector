using System;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.ProcessorTests.TestEntities;
using Microsoft.Extensions.Options;

namespace Formiik.Connector.ProcessorTests.Vanguardia
{
    public class VanguardiaTestConstants
    {
        public const string FENG_CLIENT_ID = "234228CC-D110-4DC8-B669-499BC7348E4E";
        private const string COLOCACION_PRODUCT_ID = "2b606615-3cff-472d-be6b-ce8e412496cb";
        private const string RESOURCES_FOLDER = "Vanguardia/Resources/";
        internal const string ADMIN_FDLM_USR = "martin@vanguardiab2c.onmicrosoft.com";
        internal const string ADMIN_FDLM_PWD = "V4nGu4rd14";
        
        
        public static TestEntityInfo FirstRule
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "58f63e5f-a3d9-1642-7c7d-bac862f388ad";
                info.ResourceFolder = RESOURCES_FOLDER + "01_8ad_FirstRule";
                info.SectionId = "Tarea1";
                
                return info;
            }
        }
        
        public static TestEntityInfo SecondRule
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "edde7a95-2ec6-49e8-998b-80af65e63a58";
                info.ResourceFolder = RESOURCES_FOLDER + "02_A58_PesSolicitudCredito";
                info.SectionId = "Tarea2";
                
                return info;
            }
        }
        
        public static TestEntityInfo ThirdRule
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "26e1fae5-e9d3-4ae1-98ed-d864f6678566";
                info.ResourceFolder = RESOURCES_FOLDER + "03_566_ThirdRule";
                info.SectionId = "Tarea3";
                
                return info;
            }
        }
        
        public static TestEntityInfo FourthRule
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "8d9a5a84-9264-49aa-ac7e-3360830f7a41";
                info.ResourceFolder = RESOURCES_FOLDER + "04_A41_FourthRule";
                info.SectionId = "Tarea4";
                
                return info;
            }
        }
        
        private static TestEntityInfo GetDefaultObject()
        {
            return new TestEntityInfo
            {
                // Mobile
                FormiikClientId = FENG_CLIENT_ID,
                IdWorkOrderType = new Guid("ced9ba1e-1232-4ec7-95ca-635cefab0e9e"),
                FormName = "SolicitudForomic",
                FormVersion = "1.0",
                AssignmentPriority = 1, // default en formiik
                ProductId = COLOCACION_PRODUCT_ID, // colocación,
                HoursAddToExpirationDate = 24,
                HoursAddToCancellationDate = 48,
                XsltFormiikToEngineFileName = "Tranform_FormiikToEngine.xslt",
                XsltFormiikToEngineDescription = "Transforma: Formiik => Engine",
                FlexibleUpdateExampleFileName = "FlexibleUpdateReq.json",
                
                // Engine
                EngineTenantId = "35412e1e-9e4d-4e46-82f9-6a0985277522",
                DefinitionId = "4c51eef0-c786-6b2e-a667-1b728399a70b",
                RequirementExampleFileName = "EngineRequirement.json",
                XsltEngineToFormiikFileName = "Tranform_EngineToFormiik.xslt",
                XsltEngineToFormiikDescription = "Transforma: Formiik <= Engine",
            };
        }
        
        public static IOptions<ApiEngineConfiguration> ConstantesPrueba()
        {
            var settings = new ApiEngineConfiguration()
            {
                AuthorizationHeader= "Authorization",
                CreateInstancesUrl= "https://engine-vanguardia.azure-api.net/core-mobile/api/Instances",
                PartialSaveRequirementUrl= "https://engine-vanguardia.azure-api.net/core-mobile/api/Instances/putValue",
                ProcessRequirementUrl= "https://engine-vanguardia.azure-api.net/core-mobile/api/Instances/putProcessInstance",
                GetRequirementByStatusUrl= "https://engine-vanguardia.azure-api.net/core-mobile/api/Instances/GetByStatus/",
                GetRequirementUrl= "https://engine-vanguardia.azure-api.net/core-mobile/api/Instances/",
                NewCommentsUrl= "https://engine-vanguardia.azure-api.net/core-mobile/api/Instances/putStoreValidation",
                ResolveCommentsUrl= "https://engine-vanguardia.azure-api.net/core-mobile/api/Instances/putResolveValidation",
                GetRequirementAltUrl= "https://prod-28.southcentralus.logic.azure.com:443/workflows/ff90e3c757a447e48986764bbface7ac/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=vAIsLsLEwSdHmVYEkjrXF6---Z9v1V7XMVNC0bwTiGc",
                HeaderSuscriptionKey= "Ocp-Apim-Subscription-Key",
                HeaderSuscriptionValue= "225d603e317e4893b4207645a87f194d"
            };
            IOptions<ApiEngineConfiguration> options = Options.Create(settings);

            return options;
        }
    }
}