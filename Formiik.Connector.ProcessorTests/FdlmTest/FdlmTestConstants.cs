using System;
using Formiik.Connector.Entities;
using Formiik.Connector.ProcessorTests.TestEntities;

namespace Formiik.Connector.ProcessorTests.FdlmTest
{
    /// <summary>
    /// Values for Fundacion de la mujer
    /// </summary>
    public static class FdlmTestConstants
    {
        public const string FENG_CLIENT_ID = "fd9690bc-31b3-4e9a-b498-6ff908a4231b";

        private const string COLOCACION_PRODUCT_ID = "179f7adb-0077-476f-abde-462d92e0fb26";
        
        
        private const string RESOURCES_FOLDER = "FdlmTest/Resources/";
        
        #region - 01 Pre Evaluacion-
        
        public static TestEntityInfo PesPreEva
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "F5057794-0AC3-4C3A-A131-04858E764F27";
                info.ResourceFolder = RESOURCES_FOLDER + "01_F27_PesPreEva";
                info.SectionId = "PesPreEva";
                
                return info;
            }
        }
        
        #endregion
        
//        #region -  02 Centrales de Riesgo-
//        
//        public static TestEntityInfo PesCenRie
//        {
//            get
//            {
//                var info = GetDefaultObject();
//                info.ContanierId = "";
//                info.ResourceFolder = RESOURCES_FOLDER + "02_PesCenRie";
//                info.SectionId = "PesCenRie";                
//                return info;
//            }
//        }
//        
//        #endregion 
        
        #region - 03 Pre-solicitud -
        
        public static TestEntityInfo PesPreSol
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "4FAE0F21-C80B-4851-AD0E-9D682D338280";
                info.ResourceFolder = RESOURCES_FOLDER + "03_280_PesPreSol";
                info.SectionId = "PesPreSol";
                
                return info;
            }
        }
        
        #endregion   
        
        #region - 04 Análisis -
        
        public static TestEntityInfo PesAnaSol
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "9580909E-777F-4F12-A93A-5F4A27E24AD6";
                info.ResourceFolder = RESOURCES_FOLDER + "04_AD6_PesAnaSol";
                info.SectionId = "PesAnaSol";
                
                return info;
            }
        }
        
        #endregion  
        
        #region - 05 Toma de Información del Negocio -
        
        public static TestEntityInfo TomInfBal
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "7BAAE610-AEEA-4DCC-A7DD-3D6E18A3347F";
                info.ResourceFolder = RESOURCES_FOLDER + "05_47F_TomInfBal";
                info.SectionId = "TomInfBal";
                
                return info;
            }
        }
        
        #endregion  
        
        #region - 06 Referencias, codeudores y garantías -
        
        public static TestEntityInfo PesCodGar
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "3F6F9972-901B-49AB-86CB-4E07AFA51C57";
                info.ResourceFolder = RESOURCES_FOLDER + "06_C57_PesCodGar";
                info.SectionId = "PesCodGar";
                
                return info;
            }
        }
        
        #endregion  
        
        #region - 07 Pólizas -
        
        public static TestEntityInfo PesPol
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "21D50DF8-A522-4E58-9FD8-90F8916EBEEF";
                info.ResourceFolder = RESOURCES_FOLDER + "07_EEF_PesPol";
                info.SectionId = "PesPol";
                
                return info;
            }
        }
        
        #endregion
        
        #region - 08 Evaluación (PesEva) -
        
        public static TestEntityInfo PesEva
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "F5716E1C-1B22-48B6-A76C-2BF769D4CC1B";
                info.ResourceFolder = RESOURCES_FOLDER + "08_C1B_PesEva";
                info.SectionId = "PesEva";
                
                return info;
            }
        }
        
        #endregion 
        
        #region - 09 Recomendación -
        
        public static TestEntityInfo PesRec
        {
            get
            {
                var info = GetDefaultObject();
                info.ContanierId = "7DA96C69-418F-4C36-9DEF-10B309F5F528";
                info.ResourceFolder = RESOURCES_FOLDER + "09_528_PesRec";
                info.SectionId = "PesRec";
                
                return info;
            }
        }
        
        #endregion

        private static TestEntityInfo GetDefaultObject()
        {
            return new TestEntityInfo
            {
                // Mobile
                FormiikClientId = FENG_CLIENT_ID,

                IdWorkOrderType = new Guid("e2e601e6-f4fa-415f-92bc-6513be13bfa6"),
                
                FormName = "Solicitud",

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

                DefinitionId = "24D48A1F-88EC-48F4-816B-F89971449EB2",

                RequirementExampleFileName = "EngineRequirement.json",

                XsltEngineToFormiikFileName = "Tranform_EngineToFormiik.xslt",

                XsltEngineToFormiikDescription = "Transforma: Formiik <= Engine",
            };
        }
    }
}