using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Processor.EngineProxy;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.FormiikToEngineTest
{
    public class ResponsesProcessorTests
    {
        private string usr = TestConstants.ADMIN_FDLM_USR;
        private string pwd = TestConstants.ADMIN_FDLM_PWD;
        private const string RESOURCE_FOLDER = "FirstDelivery/Resources/";

        [Fact]
        public void ProcessResponse_Test()
        {
            string fullXmlResponse = FileUtil.ReadContentFromResource(RESOURCE_FOLDER, "FullResponse.xml");

            var headers = LoginUtilsTests.GetRequestHeaders(usr, pwd);
            
            IResponsesProcessor processor = new ResponsesProcessor(TestConstants.ConstantesPrueba());
            var response = processor.ProcessResponse(headers, fullXmlResponse).Result;
            
            Assert.NotNull(response);
        }
    }
}