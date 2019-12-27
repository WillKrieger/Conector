using System;
using System.Text;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Processor.EngineProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FdlmTest.MobileToEngineTest
{
    public class TransformFormiikToEngineTests
    {
        private const string FULL_RESPONSE_XML = "FdlmTest/Resources/FullResponse.xml";
        
        //private const string FULL_RESPONSE_XML = "FdlmTest/Resources/FullResponseFake.xml";
        
        private const string OUTPUT_FILDER = "MobileToEngine";

        private const bool REMOVE_NULLS = false;

        #region - 01 Pre Evaluacion (PesPreEva) -

        [Fact]
        public void PesPreEva_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.PesPreEva);
        }

        [Fact]
        public void TransformResponse_PesPreEva_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.PesPreEva);
        }

        #endregion

        #region - 03 Pre-solicitud (PesPreSol) -

        [Fact]
        public void TransformFlexibleUpdate_PesPreSol_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.PesPreSol);
        }

        [Fact]
        public void TransformResponse_PesPreSol_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.PesPreSol);
        }

        #endregion

        #region - 04 Análisis (PesAnaSol) -

        [Fact]
        public void TransformFlexibleUpdate_PesAnaSol_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.PesAnaSol);
        }

        [Fact]
        public void TransformResponse_PesAnaSol_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.PesAnaSol);
        }

        #endregion

        #region - 05 Toma de Información del Negocio (TomInfBal) -

        [Fact]
        public void TransformFlexibleUpdate_TomInfBal_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.TomInfBal);
        }

        [Fact]
        public void TransformResponse_TomInfBal_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.TomInfBal);
        }

        #endregion

        #region - 06 Referencias, codeudores y garantías (PesCodGar) -

        [Fact]
        public void TransformFlexibleUpdate_PesCodGar_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.PesCodGar);
        }

        [Fact]
        public void TransformResponse_PesCodGar_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.PesCodGar);
        }

        #endregion

        #region - 07 Pólizas (PesPol) -

        [Fact]
        public void TransformFlexibleUpdate_PesPol_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.PesPol);
        }

        [Fact]
        public void TransformResponse_PesPol_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.PesPol);
        }

        #endregion

        #region - 08 Evaluación (PesEva) -

        [Fact]
        public void TransformFlexibleUpdate_PesEva_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.PesEva);
        }

        [Fact]
        public void TransformResponse_PesEva_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.PesEva);
        }

        #endregion

        #region - 09 Recomendación (PesRec) -

        [Fact]
        public void TransformFlexibleUpdate_PesRec_Test()
        {
            TransformFlexibleUpdate_Test(FdlmTestConstants.PesRec);
        }

        [Fact]
        public void TransformResponse_PesRec_Test()
        {
            TransformResponseSection_Test(FdlmTestConstants.PesRec);
        }

        #endregion

        #region- Run test -

        private void TransformFlexibleUpdate_Test(TestEntityInfo testInfo)
        {
            try
            {
                string xsltFile = FileUtil.ReadContentFromResource(testInfo.ResourceFolder,
                    testInfo.XsltFormiikToEngineFileName);

                string fuReq =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder,
                        testInfo.FlexibleUpdateExampleFileName);

                var clientInfoFuReq = FormiikGenericParser.DeserializeFromJson<FlexibleUpdateRequestDto>(fuReq);

                TransformResult fuJsonRes =
                    MobileToEngineTransformer.TransformFlexibleUpdate(clientInfoFuReq, xsltFile, REMOVE_NULLS,
                        out StringBuilder warnFuJsonRes);

                Assert.NotNull(fuJsonRes);
                Assert.True(warnFuJsonRes.Length < 1, $"Trasnformation errors: {warnFuJsonRes}");

                string jsonValue = FormiikGenericParser.SerializeToJson(fuJsonRes, Formatting.Indented);
                
                string filename = System.IO.Path.Combine(OUTPUT_FILDER,
                    $"fu_{testInfo.SectionId}-{testInfo.ContanierId}.json");

                FileUtil.WriteFile(filename, jsonValue);
            }
            catch (Exception e)
            {
                string message = $"Flexibleupdate Fail: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }

        private void TransformResponseSection_Test(TestEntityInfo testInfo)
        {
            try
            {
                var response = ResponseReaderUtil.GetSection(FULL_RESPONSE_XML, testInfo.SectionId);

                string xsltFile =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder, testInfo.XsltFormiikToEngineFileName);

                TransformResult respJsonRes =
                    MobileToEngineTransformer.TransformResponse(response, xsltFile, REMOVE_NULLS,
                        out StringBuilder warnRespJsonRes);

                Assert.NotNull(respJsonRes);
                Assert.True(warnRespJsonRes.Length < 1, $"Trasnformation errors: {warnRespJsonRes}");

                string jsonValue = FormiikGenericParser.SerializeToJson(respJsonRes, Formatting.Indented);

                string filename = System.IO.Path.Combine(OUTPUT_FILDER,
                    $"resp_{testInfo.SectionId}-{testInfo.ContanierId}.json");

                FileUtil.WriteFile(filename, jsonValue);
            }
            catch (Exception e)
            {
                string message = $"Transform Response Fail: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }

        #endregion
    }
}