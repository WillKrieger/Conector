using System.IO;
using System.Threading.Tasks;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.FormiikToEngineTest.ConfigTest
{
    public class ConfigFlexibleUpdateRulesTests
    {
        [Fact]
        public void ConfigureRules_FormiikToEngine_Tests()
        {
            var tsXsltRules =
                new AzureTableStorage<TsRequirementTranformRule>(GeneralConstants.TS_XSLT_REQUIREMENTS_RULES);

            // BusqCliente
            var busqCliente = TestConstants.BusqCliente_111;
            
            ConfigureRule(
                    tsXsltRules,
                    busqCliente.SectionId,
                    busqCliente.ContanierId,
                    Path.Combine(busqCliente.ResourceFolder, busqCliente.XsltFormiikToEngineFileName),
                    busqCliente.XsltFormiikToEngineDescription)
                .Wait();
            
            // InfoClienteFam
            var infoClienteyFam = TestConstants.InfoClienteFam_112;
            
            ConfigureRule(
                tsXsltRules,
                infoClienteyFam.SectionId,
                infoClienteyFam.ContanierId,
                Path.Combine(infoClienteyFam.ResourceFolder, infoClienteyFam.XsltFormiikToEngineFileName),
                infoClienteyFam.XsltFormiikToEngineDescription
            ).Wait();

            // DatosNeg
            var datosNegInfo = TestConstants.DatosNeg_113;
            
            ConfigureRule(
                tsXsltRules,
                datosNegInfo.SectionId,
                datosNegInfo.ContanierId,
                Path.Combine(datosNegInfo.ResourceFolder, datosNegInfo.XsltFormiikToEngineFileName),
                datosNegInfo.XsltFormiikToEngineDescription
            ).Wait();
            
            var recomendacion = TestConstants.Recomendacion_114;
            
            ConfigureRule(
                tsXsltRules, 
                recomendacion.SectionId, 
                recomendacion.ContanierId,
                Path.Combine(recomendacion.ResourceFolder, recomendacion.XsltFormiikToEngineFileName),
                datosNegInfo.XsltFormiikToEngineDescription
                ).Wait();
        }

        private async Task ConfigureRule(
            AzureTableStorage<TsRequirementTranformRule> table, 
            string sectionId, 
            string containerId, 
            string filePath, 
            string descriptions)
        {
            string xsltContent = FileUtil.ReadContentFromResource(filePath);
            
            var rule = new TsRequirementTranformRule()
            {
                ClientId = TestConstants.FENG_CLIENT_ID,
                RuleId = sectionId,
                SectionId = sectionId,
                ContainerId = containerId,
                XsltTransformation = xsltContent,
                RemoveNullAndEmty = true,
                Description = descriptions
            };
            
            await table.Delete(rule.PartitionKey, rule.RowKey);

            await table.Insert(rule);
        }
    }
}