using System;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.MobileProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.Vanguardia.EngineToMobileTest
{
    public class TransforEngineToFormiikTests
    {
        private const string OUTPUT_FILDER = "EngineToMobile";
        
        [Fact]
        public void FirstRule_Transform_Test()
        {
            RunTrans(VanguardiaTestConstants.FirstRule);
        }
        
        [Fact]
        public void SecondRule_Transform_Test()
        {
            RunTrans(VanguardiaTestConstants.SecondRule);
        }
        
        private NewWorkOrder RunTrans(TestEntityInfo testInfo)
        {
            NewWorkOrder newOrderInFormiik = null;

            try
            {
                string xsltFile =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder, testInfo.XsltEngineToFormiikFileName);

                string engineRequirementtext =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder, testInfo.RequirementExampleFileName);

                var requirementAsJson =
                    FormiikGenericParser.DeserializeFromJson<IncomeRequirementInfoDto>(engineRequirementtext);

                var transformRules = new TsRequirementTranformRule()
                {
                    ClientId = testInfo.FormiikClientId,
                    RuleId = testInfo.ContanierId,
                    ContainerId = testInfo.ContanierId,
                    XsltTransformation = xsltFile,
                    FormInFormiik = testInfo.FormName,
                    FormVersionInFormiik = testInfo.FormVersion,
                    AssignmentPriority = testInfo.AssignmentPriority,
                    ProductId = testInfo.ProductId,
                    HoursAddToExpirationDate = testInfo.HoursAddToExpirationDate,
                    HoursAddToCancellationDate = testInfo.HoursAddToCancellationDate
                };

                newOrderInFormiik =
                    EngineToMobileTransformer.TransformToNewWorkOrder(requirementAsJson, transformRules);

                Assert.NotNull(newOrderInFormiik);
                
                string jsonValue = FormiikGenericParser.SerializeToJson(newOrderInFormiik, Formatting.Indented);

                string filename = System.IO.Path.Combine(OUTPUT_FILDER,
                    $"resp_{testInfo.SectionId}-{testInfo.ContanierId}.json");

                Console.WriteLine(FileUtil.WriteFile(filename, jsonValue));
            }
            catch (Exception e)
            {
                string message = $"Transformation Fail '{testInfo.SectionId}': {e.Message}";
                Assert.True(e == null, message);
            }

            return newOrderInFormiik;
        }
        
    }
}