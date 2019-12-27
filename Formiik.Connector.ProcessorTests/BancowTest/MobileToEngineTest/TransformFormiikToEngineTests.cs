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

namespace Formiik.Connector.ProcessorTests.BancowTest.MobileToEngineTest
{
    public class TransformFormiikToEngineTests
    {
        private const string FULL_RESPONSE_XML = "BancowTest/Resources/FullResponse.xml";
        private const string OUTPUT_FILDER = "MobileToEngine";
        private const bool REMOVE_NULLS = false;

        [Fact]
        public void ConsultaCliente_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(BancowTestConstants.ConsultaCliente);
        }

        [Fact]
        public void Radicacion_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(BancowTestConstants.Radicacion);
        }

        [Fact]
        public void AnalisisCredito_131_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(BancowTestConstants.AnalisisCredito_131);
        }

        [Fact]
        public void AnalisisCredito_132_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(BancowTestConstants.AnalisisCredito_132);
        }

        [Fact]
        public void AnalisisCredito_133_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(BancowTestConstants.AnalisisCredito_133);
        }

        [Fact]
        public void AnalisisCredito_134_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(BancowTestConstants.AnalisisCredito_134);
        }

        [Fact]
        public void AnalisisCredito_135_TransformFlexibleUpdate_Test()
        {
            TransformFlexibleUpdate_Test(BancowTestConstants.AnalisisCredito_135);
        }

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
