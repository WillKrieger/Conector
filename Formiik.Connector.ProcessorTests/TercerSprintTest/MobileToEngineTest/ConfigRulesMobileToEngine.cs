using System;
using System.IO;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.TercerSprintTest.MobileToEngineTest
{
    public class ConfigRulesMobileToEngine
    {
        #region - 01 Identificacion del Sujeto -

        [Fact]
        public void PesPreEva_WriteRuleConfig_Test()
        {
            WriteRule(TercerSprintTestConstants.SolCreNor);
        }

        #endregion

        #region - 02 Datos del Sujeto -

        [Fact]
        public void TabEvaNeg_WriteRuleConfig_Test()
        {
            WriteRule(TercerSprintTestConstants.TabEvaNeg);
        }

        #endregion
        
        #region - 03 Datos del Negocio -
        [Fact]
        public void TabEvaNegNew_WriteRuleConfig_Test()
        {
            WriteRule(TercerSprintTestConstants.TabEvaNegNew);
        }
        #endregion
        
        #region - 04 Activos del Negocio -
        [Fact]
        public void TabDatNeg_WriteRuleConfig_Test()
        {
            WriteRule(TercerSprintTestConstants.TabDatNeg);
        }
        #endregion
        
        #region - 05 Aceptacion del Credito -
        [Fact]
        public void TabAceCre_WriteRuleConfig_Test()
        {
            WriteRule(TercerSprintTestConstants.TabAceCre);
        }
        #endregion
        
        #region - 06 Tabla de Amortizacion -
        [Fact]
        public void TabTblAmo_WriteRuleConfig_Test()
        {
            WriteRule(TercerSprintTestConstants.TabTblAmo);
        }
        #endregion
        
        #region - 07 Aceptacion del Desembolso -
        [Fact]
        public void TabAceDes_WriteRuleConfig_Test()
        {
            WriteRule(TercerSprintTestConstants.TabAceDes);
        }
        #endregion
        
        #region- Write Mobile to Engine rules -

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

        #endregion
    }
}