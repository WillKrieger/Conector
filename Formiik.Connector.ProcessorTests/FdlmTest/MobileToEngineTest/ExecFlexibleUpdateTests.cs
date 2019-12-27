using System;
using System.Linq;
using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Processor.EngineProxy;
using Formiik.Connector.ProcessorTests.FirstDelivery;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FdlmTest.MobileToEngineTest
{
    public class ExecFlexibleUpdateTests
    {
        private string usr = TestConstants.ADMIN_FDLM_USR;
        private string pwd = TestConstants.ADMIN_FDLM_PWD;

        #region - 01 Pre Evaluacion (PesPreEva) -

        [Fact]
        public void PesPreEva_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.PesPreEva);
        }

        #endregion

        #region - 03 Pre-solicitud -

        [Fact]
        public void PesPreSol_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.PesPreSol);
        }

        #endregion

        #region - 04 Análisis -

        [Fact]
        public void PesAnaSol_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.PesAnaSol);
        }

        #endregion

        #region - 05 Toma de Información del Negocio -

        [Fact]
        public void TomInfBal_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.TomInfBal);
        }

        #endregion

        #region - 06 Referencias, codeudores y garantías -

        [Fact]
        public void PesCodGar_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.PesCodGar);
        }

        #endregion

        #region - 07 Pólizas -

        [Fact]
        public void PesPol_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.PesPol);
        }

        #endregion

        #region - 08 Evaluación (PesEva) -

        [Fact]
        public void PesEva_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.PesEva);
        }

        #endregion

        #region - 09 Recomendación -

        [Fact]
        public void PesRec_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(FdlmTestConstants.PesRec);
        }

        #endregion

        private void ExecuteFlexibleUpdate(TestEntityInfo testInfo)
        {
            try
            {
                string searchInfoTxt =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder,
                        testInfo.FlexibleUpdateExampleFileName);

                var flexibleUpdateRequest = JsonConvert.DeserializeObject<FlexibleUpdateRequestDto>(searchInfoTxt);

                var headers = LoginUtilsTests.GetRequestHeaders(usr, pwd);

                IFlexibleUpdateProcessor processor = new FlexibleUpdateProcessor(TestConstants.ConstantesPrueba());
                var response = processor.SendRequestToPlatform(headers, flexibleUpdateRequest).Result;
                Assert.NotNull(response);

                if (response.FormiikReservedWords != null)
                {
                    var clientError =
                        response.FormiikReservedWords.FirstOrDefault(p => p.ReservedWord == "ClientError");
                    
                    var userMessageError =
                        response.FormiikReservedWords.FirstOrDefault(p => p.ReservedWord == "AlertMessage");

                    Assert.True(clientError == null, userMessageError.Value);
                }
            }
            catch (Exception e)
            {
                string message = $"Flexibleupdate Fail: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }
    }
}