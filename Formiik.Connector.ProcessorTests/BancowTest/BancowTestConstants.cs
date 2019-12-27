using System;
using Formiik.Connector.ProcessorTests.TestEntities;

namespace Formiik.Connector.ProcessorTests.BancowTest
{
    public class BancowTestConstants
    {
        //Falta revisar identificadores
        public const string FENGT_CLIENT_ID = "851ccbfc-3abc-46ab-80c5-39aa3c67d661";
        private const string COLOCACION_PRODUCT_ID = "fa050bf8-5bb7-408c-a866-95b5159222ca";
        private const string RESOURCES_FOLDER = "BancowTest/Resources/";

        #region 01 - Consulta de Cliente
        public static TestEntityInfo ConsultaCliente
        {
            get
            {
                var info = GetDefaultObject();
                //Falta identificador de Container
                info.ContanierId = "100-00000-0000-0111";
                info.ResourceFolder = RESOURCES_FOLDER + "01_111_ConsultaCliente";
                info.SectionId = "ConsultaCliente";

                return info;
            }
        }
        #endregion

        #region 02 - Radicacion
        public static TestEntityInfo Radicacion
        {
            get
            {
                var info = GetDefaultObject();
                //Falta identificador de Container
                info.ContanierId = "100-00000-0000-0121";
                info.ResourceFolder = RESOURCES_FOLDER + "02_121_Radicacion";
                info.SectionId = "Radicacion";

                return info;
            }
        }
        #endregion

        #region 03 - AnalisisCredito 1ra Parte
        public static TestEntityInfo AnalisisCredito_131
        {
            get
            {
                var info = GetDefaultObject();
                //Falta identificador de Container
                info.ContanierId = "100-00000-0000-0131";
                info.ResourceFolder = RESOURCES_FOLDER + "03_131_AnalisisCredito";
                info.SectionId = "AnalisisCredito";

                return info;
            }
        }
        #endregion

        #region
        public static TestEntityInfo AnalisisCredito_132
        {
            get
            {
                var info = GetDefaultObject();
                //Falta identificador de Container
                info.ContanierId = "100-00000-0000-0132";
                info.ResourceFolder = RESOURCES_FOLDER + "04_132_AnalisisCredito";
                info.SectionId = "AnalisisCredito";

                return info;
            }
        }
        #endregion

        #region
        public static TestEntityInfo AnalisisCredito_133
        {
            get
            {
                var info = GetDefaultObject();
                //Falta identificador de Container
                info.ContanierId = "100-00000-0000-0133";
                info.ResourceFolder = RESOURCES_FOLDER + "05_133_AnalisisCredito";
                info.SectionId = "AnalisisCredito";

                return info;
            }
        }
        #endregion

        #region
        public static TestEntityInfo AnalisisCredito_134
        {
            get
            {
                var info = GetDefaultObject();
                //Falta identificador de Container
                info.ContanierId = "100-00000-0000-0134";
                info.ResourceFolder = RESOURCES_FOLDER + "06_134_AnalisisCredito";
                info.SectionId = "AnalisisCredito";

                return info;
            }
        }
        #endregion

        #region
        public static TestEntityInfo AnalisisCredito_135
        {
            get
            {
                var info = GetDefaultObject();
                //Falta identificador de Container
                info.ContanierId = "100-00000-0000-0135";
                info.ResourceFolder = RESOURCES_FOLDER + "07_135_AnalisisCredito";
                info.SectionId = "AnalisisCredito";

                return info;
            }
        }
        #endregion

        private static TestEntityInfo GetDefaultObject()
        {
            return new TestEntityInfo
            {
                // Mobile
                FormiikClientId = FENGT_CLIENT_ID,
                IdWorkOrderType = new Guid("4F32F357-5110-41F1-96DD-8554C7C3DCFC"),
                FormName = "SOLN",
                FormVersion = "1.0",
                AssignmentPriority = 1, // default en formiik
                ProductId = COLOCACION_PRODUCT_ID, // colocación,
                HoursAddToExpirationDate = 24,
                HoursAddToCancellationDate = 48,
                XsltFormiikToEngineFileName = "Transform_FormiikToEngine.xslt",
                XsltFormiikToEngineDescription = "Transforma: Formiik => Engine",
                FlexibleUpdateExampleFileName = "FlexibleUpdateReq.json",

                // Engine
                EngineTenantId = "85cf9832-e665-4950-8d76-257705460e96",
                DefinitionId = "BB787FE3-D502-4492-9A62-B7F8D1FBD40B",
                RequirementExampleFileName = "EngineRequirement.json",
                XsltEngineToFormiikFileName = "Tranform_EngineToFormiik.xslt",
                XsltEngineToFormiikDescription = "Transforma: Formiik <= Engine",
            };
        }
    }
}
