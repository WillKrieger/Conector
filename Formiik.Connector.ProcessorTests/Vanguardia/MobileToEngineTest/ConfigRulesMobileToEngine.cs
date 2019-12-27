using System;
using System.IO;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.Vanguardia.MobileToEngineTest
{
    public class ConfigRulesMobileToEngine
    {
        [Fact]
        public void FirstRule_WriteRuleConfig_Test()
        {
            WriteRule(VanguardiaTestConstants.FirstRule);
        }
        
        [Fact]
        public void SecondRule_WriteRuleConfig_Test()
        {
            WriteRule(VanguardiaTestConstants.SecondRule);
        }
        
        [Fact]
        public void ThirdRule_WriteRuleConfig_Test()
        {
            WriteRule(VanguardiaTestConstants.ThirdRule);
        }
        
        [Fact]
        public void FourthRule_WriteRuleConfig_Test()
        {
            WriteRule(VanguardiaTestConstants.FourthRule);
        }
        
        
        
        private void WriteRule(TestEntityInfo testInfo)
        {
            try
            {
                string filePath = Path.Combine(testInfo.ResourceFolder, testInfo.XsltFormiikToEngineFileName);
                
                string xsltContent = FileUtil.ReadContentFromResource(filePath);
            
                var rule = new TsRequirementTranformRule()
                {
                    ClientId = testInfo.FormiikClientId,
                    SectionId = testInfo.SectionId,
                    ContainerId = testInfo.ContanierId,
                    XsltTransformation = xsltContent,
                    RemoveNullAndEmty = true,
                    Description = testInfo.XsltFormiikToEngineDescription,
                    DefinitionId = testInfo.DefinitionId
                };

                TransformationRulesStorage.SaveRuleMobileToEngine(testInfo.IdWorkOrderType, testInfo.SectionId, rule)
                    .Wait();
            }
            catch (Exception e)
            {
                string message = $"Write rule Fail: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }
    }
}