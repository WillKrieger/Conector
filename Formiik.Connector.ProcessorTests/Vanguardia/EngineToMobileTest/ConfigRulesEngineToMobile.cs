using System;
using System.Collections.Generic;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.Vanguardia.EngineToMobileTest
{
    public class ConfigRulesEngineToMobile
    {
        [Fact]
        public void FirstRule_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(VanguardiaTestConstants.FirstRule, statusRules);
        }
        
        [Fact]
        public void SecondRule_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(VanguardiaTestConstants.SecondRule, statusRules);
        }
        
        [Fact]
        public void ThirdRule_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(VanguardiaTestConstants.ThirdRule, statusRules);
        }
        
        private void WriteRule(TestEntityInfo testInfo, List<TransformRuleByRequirementStatus> customStatusRules = null)
        {
            try
            {
                string infoClientXslt = FileUtil.ReadContentFromResource(testInfo.ResourceFolder, testInfo.XsltEngineToFormiikFileName);
                
                var rule = new TsRequirementTranformRule()
                {
                    ClientId = testInfo.FormiikClientId,
                    ProductId = testInfo.ProductId,
                    DefinitionId = testInfo.DefinitionId,
                    ContainerId = testInfo.ContanierId,
                    XsltTransformation = infoClientXslt,
                    FormInFormiik = testInfo.FormName,
                    FormVersionInFormiik = testInfo.FormVersion,
                    SectionId = testInfo.SectionId,
                    Description = testInfo.XsltEngineToFormiikDescription,
                    HoursAddToCancellationDate = testInfo.HoursAddToCancellationDate,
                    HoursAddToExpirationDate = testInfo.HoursAddToExpirationDate,
                    TenantId = testInfo.EngineTenantId,
                    IdWorkOrderType = testInfo.IdWorkOrderType.ToString()
                };

                if (customStatusRules != null && customStatusRules.Count > 0)
                {
                    rule.RulesApliedToStatusAsJson = FormiikGenericParser.SerializeToJson(customStatusRules);    
                }

                TransformationRulesStorage.SaveRuleEngineToMobile(testInfo.ContanierId, rule).Wait();
            }
            catch (Exception e)
            {
                string message = $"Fail write rule Engine => Formiik: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }
    }
}