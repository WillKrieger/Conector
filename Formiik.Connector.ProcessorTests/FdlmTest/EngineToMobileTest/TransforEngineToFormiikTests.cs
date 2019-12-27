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

namespace Formiik.Connector.ProcessorTests.FdlmTest.EngineToMobileTest
{
    public class TransforEngineToFormiikTests
    {
        private const string OUTPUT_FILDER = "EngineToMobile";
        #region - 01 Pre Evaluacion -

        [Fact]
        public void PesPreEva_Transform_Test()
        {
            RunTrans(FdlmTestConstants.PesPreEva);
        }

        #endregion

        #region - 03 Pre-solicitud (PesPreSol) -

        [Fact]
        public void PesPreSol_Transform_Test()
        {
            RunTrans(FdlmTestConstants.PesPreSol);
        }

        #endregion

        #region - 04 Análisis (PesAnaSol) -

        [Fact]
        public void PesAnaSol_Transform_Test()
        {
            RunTrans(FdlmTestConstants.PesAnaSol);
        }

        #endregion

        #region - 05 Toma de Información del Negocio (TomInfBal) -

        [Fact]
        public void TomInfBal_Transform_Test()
        {
            RunTrans(FdlmTestConstants.TomInfBal);
        }

        #endregion

        #region - 06 Referencias, codeudores y garantías (PesCodGar) -

        [Fact]
        public void PesCodGar_Transform_Test()
        {
            RunTrans(FdlmTestConstants.PesCodGar);
        }

        #endregion

        #region - 07 Pólizas (PesPol) -

        [Fact]
        public void PesPol_Transform_Test()
        {
            RunTrans(FdlmTestConstants.PesPol);
        }

        #endregion

        #region - 08 Evaluación (PesEva) -

        [Fact]
        public void PesEva_Transform_Test()
        {
            RunTrans(FdlmTestConstants.PesEva);
        }

        #endregion

        #region - 09 Recomendación (PesRec) -

        [Fact]
        public void PesRec_Transform_Test()
        {
            RunTrans(FdlmTestConstants.PesRec);
        }

        #endregion

        #region- Run test -

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

        #endregion
    }
}