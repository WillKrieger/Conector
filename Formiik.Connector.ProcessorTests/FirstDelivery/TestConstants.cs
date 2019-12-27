using System;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.ProcessorTests.TestEntities;
using Microsoft.Extensions.Options;

namespace Formiik.Connector.ProcessorTests.FirstDelivery
{
    internal  static class TestConstants
    {
        internal const string FENG_CLIENT_ID = "fd9690bc-31b3-4e9a-b498-6ff908a4231b";
        private const string RESOURCES_FOLDER = @"FirstDelivery/Resources/";
        
        #region - 1 Section BusqCliente-

        public static TestEntityInfo BusqCliente_111
        {
            get
            {
                return new TestEntityInfo
                {
                    ContanierId = "100-00000-0000-0111",

                    ResourceFolder = RESOURCES_FOLDER + "0111_BusqCliente",

                    SectionId = "BusqCliente",

                    RequirementExampleFileName = "EngineRequirement.json",

                    XsltFormiikToEngineFileName = "Tranform_FormiikToEngine.xslt",

                    XsltFormiikToEngineDescription = "Formiik => Engine",

                    XsltEngineToFormiikFileName = "Tranform_EngineToFormiik.xslt",

                    XsltEngineToFormiikDescription = "Engine => Formiik",

                    FlexibleUpdateExampleFileName = "FlexibleUpdateReq.json"
                };
            }
        }
        
        #endregion
        
        #region - 2 Section InfoClienteyFam - 

        public static TestEntityInfo InfoClienteFam_112
        {
            get
            {
                return new TestEntityInfo
                {
                    ContanierId = "100-00000-0000-0112",

                    ResourceFolder = RESOURCES_FOLDER + "0112_InfoClienteyFam",

                    SectionId = "InfoClienteyFam",

                    RequirementExampleFileName = "EngineRequirement.json",

                    XsltFormiikToEngineFileName = "Tranform_FormiikToEngine.xslt",

                    XsltFormiikToEngineDescription = "Formiik => Engine",

                    XsltEngineToFormiikFileName = "Tranform_EngineToFormiik.xslt",

                    XsltEngineToFormiikDescription = "Engine => Formiik",

                    FlexibleUpdateExampleFileName = "FlexibleUpdateReq.json"
                };
            }
        }
        
        #endregion
        
        #region - 3 Section DatosNeg - 

        public static TestEntityInfo DatosNeg_113
        {
            get
            {
                return new TestEntityInfo
                {
                    ContanierId = "100-00000-0000-0113",

                    ResourceFolder = RESOURCES_FOLDER + "0113_DatosNeg",

                    SectionId = "DatosNeg",

                    RequirementExampleFileName = "EngineRequirement.json",

                    XsltFormiikToEngineFileName = "Tranform_FormiikToEngine.xslt",

                    XsltFormiikToEngineDescription = "Formiik => Engine",

                    XsltEngineToFormiikFileName = "Tranform_EngineToFormiik.xslt",

                    XsltEngineToFormiikDescription = "Engine => Formiik",

                    FlexibleUpdateExampleFileName = "FlexibleUpdateReq.json"
                };
            }
        }
        
        #endregion
        
        #region - 4 Section Recomendación - 
        
        public static TestEntityInfo Recomendacion_114
        {
            get
            {
                return new TestEntityInfo
                {
                    ContanierId = "100-00000-0000-0114",

                    ResourceFolder = RESOURCES_FOLDER + "0114_Recomendacion",

                    SectionId = "Recomendacion",

                    RequirementExampleFileName = "EngineRequirement.json",

                    XsltFormiikToEngineFileName = "Tranform_FormiikToEngine.xslt",

                    XsltFormiikToEngineDescription = "Formiik => Engine",

                    XsltEngineToFormiikFileName = "Tranform_EngineToFormiik.xslt",

                    XsltEngineToFormiikDescription = "Engine => Formiik",

                    FlexibleUpdateExampleFileName = "FlexibleUpdateReq.json"
                };
            }
        }
        
        #endregion
        
        #region - Data For Formiik to Engine-
        internal const string NAME_FORM_FORMIIK = "Solicitud";
        internal const string NAME_FORM_VERSION = "4.0";
        internal const Int32 NAME_FORM_PRIORITY = 1;
        internal const string NAME_FORM_PRODUCTID = "9a7f1f24-1e18-4795-8734-64a6f1f0851f";
        #endregion
        
        #region - Data Form for Engine to Formiik requisitos 100-00000-0000-0112, 100-00000-0000-0113, 100-00000-0000-0114-
        internal const string NAME_FORM_FORMIIK_SOLICITUDASIGNADA = "SolicitudAsignada";
        internal const string NAME_FORM_VERSION_SOLICITUDASIGNADA = "1.0";
        internal const Int32  NAME_FORM_PRIORITY_SOLICITUDASIGNADA = 1;
        internal const string NAME_FORM_PRODUCTID_SOLICITUDASIGNADA = "9a7f1f24-1e18-4795-8734-64a6f1f0851f";
        #endregion
        
        internal const string SUB_FOLDER_RECOMENDACIO = "Recomendacio";
        internal const string RESPONSE_XSLT_FILE= "Tranform_FormiikToEngine.xslt";
        internal const string FLEXIBLEUPDATE_REQ_FILE = "FlexibleUpdateReq.json";

        #region - Users-
        //internal  const string LUIS_USR ="luis@formiikplatform.onmicrosoft.com";
        //internal  const string LUIS_PWD ="Puma5494";

        //internal  const string GREG_USR ="gregor@formiikplatform.onmicrosoft.com";
        //internal  const string GREG_PWD ="Cosa9314";

        //internal  const string DANTE_USR ="dante.alighieri@formiikplatform.onmicrosoft.com";
        //internal  const string DANTE_PWD ="Formiik123";

        //internal  const string SARA_SOFIA_USR ="sara.sofia@formiikplatform.onmicrosoft.com";
        //internal  const string SARA_SOFIA_PWD ="Formiik123";

        //internal  const string LUISA_USR ="luisa.fernanda@formiikplatform.onmicrosoft.com";
        //internal  const string LUISA_PWD ="Formiik123";

        //internal  const string ANA_LUCIA_USR ="ana.lucia@formiikplatform.onmicrosoft.com";
        //internal  const string ANA_LUCIA_PWD ="Formiik123";

        //internal const string ADMIN_BancoW_USR = "admin@bancowengine.onmicrosoft.com";
        //internal const string ADMIN_BancoW_PWD = "Formiik123";

        internal const string ADMIN_FDLM_USR = "admin.fdlm@fdlmb2c.onmicrosoft.com";
        internal const string ADMIN_FDLM_PWD = "FormiikMobiikQA123";
        #endregion

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