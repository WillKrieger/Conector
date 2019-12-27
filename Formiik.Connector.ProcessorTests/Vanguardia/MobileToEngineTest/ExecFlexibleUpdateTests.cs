using System;
using System.Linq;
using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Processor.EngineProxy;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.Vanguardia.MobileToEngineTest
{
    public class ExecFlexibleUpdateTests
    {
        private string usr = VanguardiaTestConstants.ADMIN_FDLM_USR;
        private string pwd = VanguardiaTestConstants.ADMIN_FDLM_PWD;

        #region - 01 Solicitud de Credito Normal -

        [Fact]
        public void SecondRule_FlexibleUpdate_Test()
        {
            ExecuteFlexibleUpdate(VanguardiaTestConstants.SecondRule);
        }

        private void ExecuteFlexibleUpdate(TestEntityInfo testInfo)
        {
            try
            {
                string searchInfoTxt =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder,
                        testInfo.FlexibleUpdateExampleFileName);

                var flexibleUpdateRequest = JsonConvert.DeserializeObject<FlexibleUpdateRequestDto>(searchInfoTxt);

                var headers = LoginUtilsTests.GetRequestHeadersVanguardia(usr, pwd);

                IFlexibleUpdateProcessor processor = new FlexibleUpdateProcessor(VanguardiaTestConstants.ConstantesPrueba());
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

        #endregion

    }
}