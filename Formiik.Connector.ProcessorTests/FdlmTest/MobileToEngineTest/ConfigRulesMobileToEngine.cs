using System;
using System.IO;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FdlmTest.MobileToEngineTest
{
    public class ConfigRulesMobileToEngine
    {
        #region - 01 Pre Evaluacion (PesPreEva) -

        [Fact]
        public void PesPreEva_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.PesPreEva);
        }

        #endregion

        #region - 03 Pre-solicitud (PesPreSol) -

        [Fact]
        public void PesPreSol_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.PesPreSol);
        }

        #endregion

        #region - 04 Análisis (PesAnaSol) -

        [Fact]
        public void PesAnaSol_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.PesAnaSol);
        }

        #endregion

        #region - 05 Toma de Información del Negocio (TomInfBal) -

        [Fact]
        public void TomInfBal_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.TomInfBal);
        }

        #endregion

        #region - 06 Referencias, codeudores y garantías (PesCodGar) -

        [Fact]
        public void PesCodGar_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.PesCodGar);
        }

        #endregion

        #region - 07 Pólizas (PesPol) -

        [Fact]
        public void PesPol_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.PesPol);
        }

        #endregion

        #region - 08 Evaluación (PesEva) -

        [Fact]
        public void PesEva_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.PesEva);
        }

        #endregion

        #region - 09 Recomendación (PesRec) -

        [Fact]
        public void PesRec_WriteRuleConfig_Test()
        {
            WriteRule(FdlmTestConstants.PesRec);
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