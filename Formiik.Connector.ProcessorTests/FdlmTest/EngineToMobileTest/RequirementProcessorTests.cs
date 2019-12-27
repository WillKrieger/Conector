using System;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Processor.MobileProxy;
using Formiik.Connector.ProcessorTests.FirstDelivery;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FdlmTest.EngineToMobileTest
{
    public class RequirementProcessorTests
    {

//        #region - 01 Pre Evaluacion (PesPreEva) -
//
//        [Fact]
//        public void PesPreEva_ProcessRequirement_Test()
//        {
//            ExecuteProcessRequirement(FdlmTestConstants.PesPreEva);
//        }
//
//        #endregion

        #region - 03 Pre-solicitud -

        [Fact]
        public void PesPreSol_ProcessRequirement_Test()
        {
            ExecuteProcessRequirement(FdlmTestConstants.PesPreSol);
        }

        #endregion

//        #region - 04 Análisis -
//
//        [Fact]
//        public void PesAnaSol_ProcessRequirement_Test()
//        {
//            ExecuteProcessRequirement(FdlmTestConstants.PesAnaSol);
//        }
//
//        #endregion
//
//        #region - 05 Toma de Información del Negocio -
//
//        [Fact]
//        public void TomInfBal_ProcessRequirement_Test()
//        {
//            ExecuteProcessRequirement(FdlmTestConstants.TomInfBal);
//        }
//
//        #endregion
//
//        #region - 06 Referencias, codeudores y garantías -
//
//        [Fact]
//        public void PesCodGar_ProcessRequirement_Test()
//        {
//            ExecuteProcessRequirement(FdlmTestConstants.PesCodGar);
//        }
//
//        #endregion
//
//        #region - 07 Pólizas -
//
//        [Fact]
//        public void PesPol_ProcessRequirement_Test()
//        {
//            ExecuteProcessRequirement(FdlmTestConstants.PesPol);
//        }
//
//        #endregion
//
//        #region - 08 Evaluación (PesEva) -
//
//        [Fact]
//        public void PesEva_ProcessRequirement_Test()
//        {
//            ExecuteProcessRequirement(FdlmTestConstants.PesEva);
//        }
//
//        #endregion
//
//        #region - 09 Recomendación -
//
//        [Fact]
//        public void PesRec_ProcessRequirement_Test()
//        {
//            ExecuteProcessRequirement(FdlmTestConstants.PesRec);
//        }
//
//        #endregion

        private void ExecuteProcessRequirement(TestEntityInfo testInfo)
        {
            try
            {
                IRequirementProcessor processor = new RequirementProcessor(TestConstants.ConstantesPrueba());
                
                string searchInfoTxt =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder,
                        testInfo.RequirementExampleFileName);

                var request = JsonConvert.DeserializeObject<IncomeRequirementInfoDto>(searchInfoTxt);

                processor.ProcessRequirementReceived(request).Wait();
            }
            catch (Exception e)
            {
                string message = $"ProcessRequirementReceived Fail: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }
    }
}