using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Processor.EngineProxy;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.FormiikToEngineTest
{
    public class FlexibleUpdateProcessorTests
    {
        private const string EXTERNAL_ID = "FU1";

        private string usr = TestConstants.ADMIN_FDLM_USR;
        private string pwd = TestConstants.ADMIN_FDLM_PWD;

        [Fact]
        public void FlexibleUpdate_BusquedaCliente_Test()
        {
            var busqCliente = TestConstants.BusqCliente_111;
                
            string searchInfoTxt = FileUtil.ReadContentFromResource(busqCliente.ResourceFolder, busqCliente.FlexibleUpdateExampleFileName);
            
            var flexibleUpdateRequest = JsonConvert.DeserializeObject<FlexibleUpdateRequestDto>(searchInfoTxt);
            
            var headers = LoginUtilsTests.GetRequestHeaders(usr, pwd);
            
            flexibleUpdateRequest.ExternalId = EXTERNAL_ID;
            IFlexibleUpdateProcessor processor = new FlexibleUpdateProcessor(TestConstants.ConstantesPrueba());
            var response = processor.SendRequestToPlatform(headers, flexibleUpdateRequest).Result;
            Assert.NotNull(response);
        }
        
        [Fact]
        public void FlexibleUpdate_InfoClientFam_Test()
        {
            var infoCliente = TestConstants.InfoClienteFam_112;
            
            string searchInfoTxt = FileUtil.ReadContentFromResource(infoCliente.ResourceFolder, infoCliente.FlexibleUpdateExampleFileName);
            
            var flexibleUpdateRequest = JsonConvert.DeserializeObject<FlexibleUpdateRequestDto>(searchInfoTxt);
            
            var headers = LoginUtilsTests.GetRequestHeaders(usr, pwd);
            
            flexibleUpdateRequest.ExternalId = EXTERNAL_ID;
            IFlexibleUpdateProcessor processor = new FlexibleUpdateProcessor(TestConstants.ConstantesPrueba());
            var response = processor.SendRequestToPlatform(headers, flexibleUpdateRequest).Result;
            Assert.NotNull(response);
        }
        
        [Fact]
        public void FlexibleUpdate_DatosNeg_Test()
        {
            var datosNegInfo = TestConstants.DatosNeg_113;
            
            string searchInfoTxt = FileUtil.ReadContentFromResource(datosNegInfo.ResourceFolder, datosNegInfo.FlexibleUpdateExampleFileName);
            
            var flexibleUpdateRequest = JsonConvert.DeserializeObject<FlexibleUpdateRequestDto>(searchInfoTxt);
            
            var headers = LoginUtilsTests.GetRequestHeaders(usr, pwd);
            
            flexibleUpdateRequest.ExternalId = EXTERNAL_ID;
            IFlexibleUpdateProcessor processor = new FlexibleUpdateProcessor(TestConstants.ConstantesPrueba());
            var response = processor.SendRequestToPlatform(headers, flexibleUpdateRequest).Result;
            Assert.NotNull(response);
        }
        
        [Fact]
        public void FlexibleUpdate_Recomendacio_Test()
        {
            string searchInfoTxt = FileUtil.ReadContentFromResource(TestConstants.BusqCliente_111.ResourceFolder, TestConstants.FLEXIBLEUPDATE_REQ_FILE);
            
            var flexibleUpdateRequest = JsonConvert.DeserializeObject<FlexibleUpdateRequestDto>(searchInfoTxt);
            
            var headers = LoginUtilsTests.GetRequestHeaders(usr, pwd);
            
            flexibleUpdateRequest.ExternalId = EXTERNAL_ID;
            IFlexibleUpdateProcessor processor = new FlexibleUpdateProcessor(TestConstants.ConstantesPrueba());
            var response = processor.SendRequestToPlatform(headers, flexibleUpdateRequest).Result;
            Assert.NotNull(response);
        }
    }
}