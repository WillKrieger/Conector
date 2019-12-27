using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Processor.MobileProxy;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.EngineToFormiikTest
{
    public class RequirementProcessorTests
    {   
        [Fact]
        public void RequirementProcessor_InfoClienteFam_Tests()
        {
            var clienteFam = TestConstants.InfoClienteFam_112;
            
            string rquirementAsText = FileUtil.ReadContentFromResource(clienteFam.ResourceFolder, clienteFam.RequirementExampleFileName);
            
            var incomeInfo = JsonConvert.DeserializeObject<IncomeRequirementInfoDto>(rquirementAsText);
            
            IRequirementProcessor processor = new RequirementProcessor(TestConstants.ConstantesPrueba());
            processor.ProcessRequirementReceived(incomeInfo).Wait();
            Assert.True(true);
        }
        
        [Fact]
        public void RequirgementProcessor_DatosNeg_Tests()
        {
            var datosNeg = TestConstants.DatosNeg_113;
            
            string rquirementAsText = FileUtil.ReadContentFromResource(datosNeg.ResourceFolder, datosNeg.RequirementExampleFileName);
            
            var incomeInfo = JsonConvert.DeserializeObject<IncomeRequirementInfoDto>(rquirementAsText);
            
            IRequirementProcessor processor = new RequirementProcessor(TestConstants.ConstantesPrueba());
            processor.ProcessRequirementReceived(incomeInfo).Wait();
            Assert.True(true);
        }
        
        [Fact]
        public void RequirementProcessor_Recomendacion_Tests()
        {
            var datosNeg = TestConstants.Recomendacion_114;
            
            string rquirementAsText = FileUtil.ReadContentFromResource(datosNeg.ResourceFolder, datosNeg.RequirementExampleFileName);
            
            var incomeInfo = JsonConvert.DeserializeObject<IncomeRequirementInfoDto>(rquirementAsText);
            
            IRequirementProcessor processor = new RequirementProcessor(TestConstants.ConstantesPrueba());
            processor.ProcessRequirementReceived(incomeInfo).Wait();
            Assert.True(true);
        }
    }
}