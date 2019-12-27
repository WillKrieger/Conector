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

namespace Formiik.Connector.ProcessorTests.BancowTest.MobileToEngineTest
{
    public class ExecFlexibleUpdateTests
    {
        private string usr = TestConstants.ADMIN_FDLM_USR;
        private string pwd = TestConstants.ADMIN_FDLM_PWD;

        #region 01 - Consulta de Cliente
        [Fact]
        public void ConsultaCliente_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(BancowTestConstants.ConsultaCliente);
        }
        #endregion

        #region 02 - Radicacion
        [Fact]
        public void Radicacion_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(BancowTestConstants.Radicacion);
        }
        #endregion

        #region 03 - Analisis de Credito 131
        [Fact]
        public void AnalisisDeCredito_FlexibleUpdate_131_Test()
        {
            ExecuteFlexibleUpdate(BancowTestConstants.AnalisisCredito_131);
        }
        #endregion

        #region 04 - Analisis de Credito 132
        [Fact]
        public void AnalisisDeCredito_FlexibleUpdate_132_Test()
        {
            ExecuteFlexibleUpdate(BancowTestConstants.AnalisisCredito_132);
        }
        #endregion

        #region 05 - Analisis de Credito 133
        [Fact]
        public void AnalisisDeCredito_FlexibleUpdate_133_Test()
        {
            ExecuteFlexibleUpdate(BancowTestConstants.AnalisisCredito_133);
        }
        #endregion

        #region 06 - Analisis de Credito 134
        [Fact]
        public void AnalisisDeCredito_FlexibleUpdate_134_Test()
        {
            ExecuteFlexibleUpdate(BancowTestConstants.AnalisisCredito_134);
        }
        #endregion

        #region 07 - Analisis de Credito 135
        [Fact]
        public void AnalisisDeCredito_FlexibleUpdate_135_Test()
        {
            ExecuteFlexibleUpdate(BancowTestConstants.AnalisisCredito_135);
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

                var headers = LoginUtilsTests.GetRequestHeadersBancoW(usr, pwd);

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
