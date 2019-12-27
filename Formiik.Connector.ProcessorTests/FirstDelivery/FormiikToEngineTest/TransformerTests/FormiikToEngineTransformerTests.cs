using System.Text;
using System.Xml;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Processor.EngineProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.FormiikToEngineTest.TransformerTests
{
    public class FormiikToEngineTransformerTests
    {
        private const bool REMOVE_NULLS = false;
        private const string RESOURCE_FOLDER = "FirstDelivery/Resources/";

        [Fact]
        public void TransformResponse_BusqCliente_Test()
        {
            
            var busqCliente = TestConstants.BusqCliente_111;
            
            var response = GetSection(busqCliente.SectionId);
            
            string xsltFile = FileUtil.ReadContentFromResource(busqCliente.ResourceFolder, busqCliente.XsltFormiikToEngineFileName);

            string fuReq =
                FileUtil.ReadContentFromResource(busqCliente.ResourceFolder, busqCliente.FlexibleUpdateExampleFileName);
            
            var clientInfoFuReq = FormiikGenericParser.DeserializeFromJson<FlexibleUpdateRequestDto>(fuReq);

            TransformResult respJsonRes =
                MobileToEngineTransformer.TransformResponse(response, xsltFile, REMOVE_NULLS, out StringBuilder warnRespJsonRes);
            Assert.NotNull(respJsonRes);
            Assert.True(warnRespJsonRes.Length < 1);
            
            TransformResult fuJsonRes =
                MobileToEngineTransformer.TransformFlexibleUpdate(clientInfoFuReq, xsltFile, REMOVE_NULLS,
                    out StringBuilder warnFuJsonRes);
            
            Assert.NotNull(fuJsonRes);
            Assert.True(warnFuJsonRes.Length < 1);
        }
        
        [Fact]
        public void TransformResponse_InfoClienteyFam_Test()
        {
            var clienteFam = TestConstants.InfoClienteFam_112;
            
            var response = GetSection(clienteFam.SectionId);

            string xsltFile =
                FileUtil.ReadContentFromResource(clienteFam.ResourceFolder, clienteFam.XsltFormiikToEngineFileName);

            string fuReq =
                FileUtil.ReadContentFromResource(clienteFam.ResourceFolder, clienteFam.FlexibleUpdateExampleFileName);
            
            var clientInfoFuReq = FormiikGenericParser.DeserializeFromJson<FlexibleUpdateRequestDto>(fuReq);
            
            StringBuilder warnTranform1;
            TransformResult jsonResult = MobileToEngineTransformer.TransformResponse(response, xsltFile, REMOVE_NULLS, out warnTranform1);

            StringBuilder warnTranform2;
            TransformResult jsonResFu = MobileToEngineTransformer.TransformFlexibleUpdate(clientInfoFuReq, xsltFile, REMOVE_NULLS, out warnTranform2);
            
            Assert.NotNull(jsonResult);
            Assert.True(warnTranform1.Length < 1);
            
            
            Assert.NotNull(jsonResFu);
            Assert.True(warnTranform2.Length < 1);
        }
        
        #region - 113-
        [Fact]
        public void TransformResponse_DatosNeg_FU_Test()
        {
            var datosNeg = TestConstants.DatosNeg_113;
         
            var response = GetSection(datosNeg.SectionId);

            string xsltFile = FileUtil.ReadContentFromResource(datosNeg.ResourceFolder, datosNeg.XsltFormiikToEngineFileName);
            
            string fuReq = FileUtil.ReadContentFromResource(datosNeg.ResourceFolder, datosNeg.FlexibleUpdateExampleFileName);
            
            var clientInfoFuReq = FormiikGenericParser.DeserializeFromJson<FlexibleUpdateRequestDto>(fuReq);
            
            StringBuilder warnTranform1;
            TransformResult jsonResult = MobileToEngineTransformer.TransformResponse(response, xsltFile, REMOVE_NULLS, out warnTranform1);
            Assert.NotNull(jsonResult);
            Assert.True(warnTranform1.Length < 1);
            
//            StringBuilder warnTranform2;
//            TransformResult jsonResFu = FormiikToEngineTransformer.TransformFlexibleUpdate(clientInfoFuReq, xsltFile, REMOVE_NULLS, out warnTranform2);
//            
//            
//            Assert.NotNull(jsonResFu);
//            Assert.True(warnTranform2.Length < 1);
        }
        
        [Fact]
        public void TransformResponse_DatosNeg_Response_Test()
        {
            var datosNeg = TestConstants.DatosNeg_113;
         
            var response = GetSection(datosNeg.SectionId);

            string xsltFile = FileUtil.ReadContentFromResource(datosNeg.ResourceFolder, datosNeg.XsltFormiikToEngineFileName);
            
            StringBuilder warnTranform1;
            TransformResult jsonResult = MobileToEngineTransformer.TransformResponse(response, xsltFile, REMOVE_NULLS, out warnTranform1);
            string transformData = FormiikGenericParser.SerializeToJson(jsonResult);
                
            Assert.NotNull(jsonResult);
            Assert.True(warnTranform1.Length < 1);
        }
        #endregion
        
        [Fact]
        public void TransformResponse_Recomendacio_Test()
        {
            var response = GetSection(TestConstants.SUB_FOLDER_RECOMENDACIO);

            string xsltFile = FileUtil.ReadContentFromResource(TestConstants.SUB_FOLDER_RECOMENDACIO, TestConstants.RESPONSE_XSLT_FILE);
            
            StringBuilder warnTranform1;
            TransformResult jsonResult = MobileToEngineTransformer.TransformResponse(response, xsltFile, REMOVE_NULLS, out warnTranform1);

            Assert.NotNull(jsonResult);

        }

        private string GetSection(string secctionName)
        {
            string fullResponse = FileUtil.ReadContentFromResource(RESOURCE_FOLDER, "FullResponse.xml");
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(fullResponse);
            XmlNode node = doc.SelectSingleNode($"/*/*/{secctionName}");

            Assert.NotNull(node);

            string xmlNode = $"<root>{node.InnerXml}</root>";
            
            return xmlNode;
        }
    }
}