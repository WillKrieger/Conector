using System;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.ProcessorTests.TestEntities;
using Microsoft.Extensions.Options;

namespace Formiik.Connector.ProcessorTests.TercerSprintTest
{
    /// <summary>
    /// Values for Fundacion de la mujer
    /// </summary>
    public static class TercerSprintTestConstants
    {
        public const string FENG_CLIENT_ID = "fd9690bc-31b3-4e9a-b498-6ff908a4231b";
        private const string COLOCACION_PRODUCT_ID = "8b3ca9af-0d76-4df6-afb1-17648cc4092c";
        private const string RESOURCES_FOLDER = "TercerSprintTest/Resources/";
        internal const string ADMIN_FDLM_USR = "admin.fdlm@fdlmb2c.onmicrosoft.com";
        internal const string ADMIN_FDLM_PWD = "FormiikMobiikQA123";
        
        #region - 01 Solicitud de Credito Normal-
        
        public static TestEntityInfo SolCreNor
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "ED64A5F1-66C9-4262-B65A-A4FFA6F38F27";
                info.ResourceFolder = RESOURCES_FOLDER + "01_861_SolCreNor";
                info.SectionId = "Tarea1";
                
                return info;
            }
        }
        
        #endregion
        
        #region - 02 Evaluacion de Negocio-
        
        public static TestEntityInfo TabEvaNeg
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "D37D71B3-66AE-4D36-861B-636E643EE507";
                info.ResourceFolder = RESOURCES_FOLDER + "02_507_TabEvaNeg";
                info.SectionId = "Tarea2";
                
                return info;
            }
        }
        
        #endregion
        
        #region - 03 Evaluacion de Negocio -

        public static TestEntityInfo TabEvaNegNew
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "697CDB23-BA5C-47F8-8408-DD93F1F385DF";
                info.ResourceFolder = RESOURCES_FOLDER + "03_5DF_TabEvaNeg";
                info.SectionId = "Tarea3";

                return info;
            }
        }
        #endregion
        
        public static TestEntityInfo TabDatNeg
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "943CEF99-66C3-4553-B269-DF436FFDD819";
                info.ResourceFolder = RESOURCES_FOLDER + "04_819_TabDatNeg";
                info.SectionId = "Tarea4";

                return info;
            }
        }
        
        public static TestEntityInfo TabAceCre
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "7A500720-A6E9-46E2-BC7C-843E43EE78C2";
                info.ResourceFolder = RESOURCES_FOLDER + "05_8C2_TabAceCre";
                info.SectionId = "Tarea5";

                return info;
            }
        }
        
        public static TestEntityInfo TabTblAmo
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "EC1C5673-884E-418E-BAFE-50BEF060BB57";
                info.ResourceFolder = RESOURCES_FOLDER + "06_B57_TabTblAmo";
                info.SectionId = "Tarea6";

                return info;
            }
        }
        
        public static TestEntityInfo TabAceDes
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "228800E2-1350-4AB5-8C43-0546E5A92EE3";
                info.ResourceFolder = RESOURCES_FOLDER + "07_EE3_TabAceDes";
                info.SectionId = "Tarea7";

                return info;
            }
        }
        
        
        
        private static TestEntityInfo GetDefaultObject()
        {
            return new TestEntityInfo
            {
                // Mobile
                FormiikClientId = FENG_CLIENT_ID,
                IdWorkOrderType = new Guid("69E59963-C994-4E3A-9662-83F4FB6D31F1"),
                FormName = "SprintReview1",
                FormVersion = "1.0",
                AssignmentPriority = 1, // default en formiik
                ProductId = COLOCACION_PRODUCT_ID, // colocación,
                HoursAddToExpirationDate = 24,
                HoursAddToCancellationDate = 48,
                XsltFormiikToEngineFileName = "Tranform_FormiikToEngine.xslt",
                XsltFormiikToEngineDescription = "Transforma: Formiik => Engine",
                FlexibleUpdateExampleFileName = "FlexibleUpdateReq.json",
                
                // Engine
                EngineTenantId = "cd03d0b3-7569-435b-9b2d-857c640979de",
                DefinitionId = "68832771-e0e5-4bff-b22a-7d7997e8e00a",
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
                CreateInstancesUrl= "https://formiik-engine-apimngmt-qa.azure-api.net/qa-mobile/api/Instances",
                PartialSaveRequirementUrl= "https://formiik-engine-apimngmt-qa.azure-api.net/qa-mobile/api/Instances/putValue",
                ProcessRequirementUrl= "https://formiik-engine-apimngmt-qa.azure-api.net/qa-mobile/api/Instances/putProcessInstance",
                GetRequirementByStatusUrl= "https://formiik-engine-apimngmt-qa.azure-api.net/qa-mobile/api/Instances/GetByStatus/",
                GetRequirementUrl= "https://formiik-engine-apimngmt-qa.azure-api.net/qa-mobile/api/Instances/",
                NewCommentsUrl= "https://formiik-engine-apimngmt-qa.azure-api.net/qa-mobile/api/Instances/putStoreValidation",
                ResolveCommentsUrl= "https://formiik-engine-apimngmt-qa.azure-api.net/qa-mobile/api/Instances/putResolveValidation",
                GetRequirementAltUrl= "https://prod-09.southcentralus.logic.azure.com/workflows/08f0f5bbc2e9425bb89e6b5469bd1bfa/triggers/manual/paths/invoke/instances/{0}/{1}?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=bIFcxwenwEh7cOy1PnJ9uDJgSECG9CGPAORaK69lBUQ",
                HeaderSuscriptionKey= "Ocp-Apim-Subscription-Key",
                HeaderSuscriptionValue= "08c520aa3b6a454d84919883cb7d8e93"
            };
            IOptions<ApiEngineConfiguration> options = Options.Create(settings);

            return options;
        }
    }
}