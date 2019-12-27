using System;
using System.Collections.Generic;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.TercerSprintTest.EngineToMobileTest
{
    public class ConfigRulesEngineToMobile
    {
         #region - 01 Solicitud de Credito Normal -
         [Fact]
        public void SolCreNor_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_OPEN,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(TercerSprintTestConstants.SolCreNor, statusRules);
        }
        #endregion

        #region - 02 Evaluacion del Negocio -
        [Fact]
        public void TabEvaNeg_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(TercerSprintTestConstants.TabEvaNeg, statusRules);
        }
        #endregion
        
        #region - 03 Evaluacion del Negocio -
        [Fact]
        public void TabEvaNegNew_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(TercerSprintTestConstants.TabEvaNegNew, statusRules);
        }
        #endregion
        
        #region - 04 Activos del Negocio -
        [Fact]
        public void TabDatNeg_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(TercerSprintTestConstants.TabDatNeg, statusRules);
        }
        #endregion
        
        #region - 05 Aceptacion del Credito -
        [Fact]
        public void TabAceCre_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_OPEN,    
                ExpecterStatusContainer = 1
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(TercerSprintTestConstants.TabAceCre, statusRules);
        }
        #endregion
        
        #region - 06 Tabla de Amortizacion -
        [Fact]
        public void TabTblAmo_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(TercerSprintTestConstants.TabTblAmo, statusRules);
        }
        #endregion

        #region - 07 Aceptacion del Desempleo -
        [Fact]
        public void TabAceDes_WriteRuleConfig_Test()
        {
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_PROCESSING,    
                ExpecterStatusContainer = 0
            };
            
            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);
            
            WriteRule(TercerSprintTestConstants.TabAceDes, statusRules);
        }
        #endregion
        
        #region- Write Mobile to Engine rules -

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

        #endregion
    }
}