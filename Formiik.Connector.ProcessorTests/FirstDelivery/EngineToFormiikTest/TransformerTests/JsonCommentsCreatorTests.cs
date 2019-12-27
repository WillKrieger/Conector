using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Processor.MobileProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.EngineToFormiikTest.TransformerTests
{
    public class JsonCommentsCreatorTests
    {
        [Fact]
        public void CreateJson_Tests()
        {
            var requirementInfo = TestConstants.DatosNeg_113;
            
            string engineRequirementtext = FileUtil.ReadContentFromResource(requirementInfo.ResourceFolder,
                requirementInfo.RequirementExampleFileName);

            var requirementAsJson =
                FormiikGenericParser.DeserializeFromJson<IncomeRequirementInfoDto>(engineRequirementtext);
            
            JsonCommentsCreator creator = new JsonCommentsCreator(requirementAsJson.values, requirementAsJson.comments);

            JObject comments = creator.CreateJson();
          
            string doc = FormiikGenericParser.SerializeToJson(comments);
            
            Assert.NotNull(comments);
        }
    }
}