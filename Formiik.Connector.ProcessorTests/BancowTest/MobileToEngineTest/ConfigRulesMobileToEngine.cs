using System;
using System.IO;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.BancowTest.MobileToEngineTest
{
    public class ConfigRulesMobileToEngine
    {
        [Fact]
        public void ConsultaCliente_WriteRuleCongif_Test()
        {
            WriteRule(BancowTestConstants.ConsultaCliente);
        }

        [Fact]
        public void Radicacion_WriteRuleCongif_Test()
        {
            WriteRule(BancowTestConstants.Radicacion);
        }

        [Fact]
        public void AnalisisCredito_131_WriteRuleCongif_Test()
        {
            WriteRule(BancowTestConstants.AnalisisCredito_131);
        }

        [Fact]
        public void AnalisisCredito_132_WriteRuleCongif_Test()
        {
            WriteRule(BancowTestConstants.AnalisisCredito_132);
        }

        [Fact]
        public void AnalisisCredito_133_WriteRuleCongif_Test()
        {
            WriteRule(BancowTestConstants.AnalisisCredito_133);
        }

        [Fact]
        public void AnalisisCredito_134_WriteRuleCongif_Test()
        {
            WriteRule(BancowTestConstants.AnalisisCredito_134);
        }

        [Fact]
        public void AnalisisCredito_135_WriteRuleCongif_Test()
        {
            WriteRule(BancowTestConstants.AnalisisCredito_135);
        }

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
