using System.Collections.Generic;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.MobileProxy.Transformer;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.EngineToFormiikTest.TransformerTests
{
    public class EngineToFormiikParserTests
    {
//        [Fact]
//        public void TransformData()
//        {   
//            TsRequirementTranformRule rulesTransform = new TsRequirementTranformRule();
//            string requestInfoClientyFam = ResourcesUtils.ReadContentFromResource(TestConstants.INFO_CLIENT_FAM_ENGINE_INPUT);
//            string infoClientXslt = ResourcesUtils.ReadContentFromResource(TestConstants.INFO_CLIENT_XSLT_ENGINE_TO_FORMIIK);
//            
//            rulesTransform = new TsRequirementTranformRule()
//            {
//                ClientId = GeneralConstants.FENG_CLIENT_ID,
//                RuleId = TestConstants.BUSQ_CLIENTE_CONTAINER_ID,
//                ContainerId = TestConstants.BUSQ_CLIENTE_CONTAINER_ID,
//                XsltTransformation = infoClientXslt,
//                FormInFormiik = TestConstants.NAME_FORM_FORMIIK
//            };
//
//            var infoRequest = FormiikGenericParser.DeserializeFromJson<IncomeRequirementInfoDto>(requestInfoClientyFam);
//            
//            var addRootToRequest = FormiikGenericParser.NodeJsonToXml(infoRequest.values.ToString());
//
//            XDocument xdocumentInput = XDocument.Parse(addRootToRequest.OuterXml);
//            
//            var parse = new EngineToFormiikParser(xdocumentInput, rulesTransform);
//            
//            var xslMarkup = parse.TransformDataToParametersAsDictionary();
//            
//            Assert.NotNull(xslMarkup);
//        }
//        
        [Fact]
        public void TransformInfoClientFam()
        {   
            var clienteFam = TestConstants.InfoClienteFam_112;
            
            string xsltFile = FileUtil.ReadContentFromResource(clienteFam.ResourceFolder, clienteFam.XsltEngineToFormiikFileName);
            
            string engineRequirementtext = FileUtil.ReadContentFromResource(clienteFam.ResourceFolder, clienteFam.RequirementExampleFileName);

            var transformRules = new TsRequirementTranformRule()
            {
                ClientId = TestConstants.FENG_CLIENT_ID,
                RuleId = clienteFam.ContanierId,
                ContainerId = clienteFam.ContanierId,
                XsltTransformation = xsltFile,
                FormInFormiik = TestConstants.NAME_FORM_FORMIIK
            };

            // values
//            var requirementAsJson = FormiikGenericParser.DeserializeFromJson<IncomeRequirementInfoDto>(engineRequirementtext);
//            
//            var addRootToRequest = FormiikGenericParser.NodeJsonToXml(requirementAsJson.values.ToString());
//
//            XDocument xdocumentInput = XDocument.Parse(addRootToRequest.OuterXml);
//            
//            var parse = new EngineToFormiikParser(xdocumentInput, transformRules);
            
            // Dictionary<string, string> values = parse.TransformDataToParametersAsDictionary();

            var requirementAsJson =
                FormiikGenericParser.DeserializeFromJson<IncomeRequirementInfoDto>(engineRequirementtext);
            
            
            // var addRootToRequest = FormiikGenericParser.NodeJsonToXml(requirementAsJson.values.ToString());
            //var addRootToRequest = FormiikGenericParser.NodeJsonToXml(requirementAsJson.comments.ToString());

            // XDocument xdocumentInput = XDocument.Parse(addRootToRequest.OuterXml);
            
            var parse = new EngineToMobileParser(requirementAsJson, transformRules);
            // var parse = new EngineToFormiikParser(xdocumentInput, transformRules);
            
            Dictionary<string, string> comments = parse.ToDictionaryValues();
            
            Assert.NotNull(comments);
        }
        
        [Fact]
        public void Transform_DatosNeg()
        {   
            var datosNeg = TestConstants.DatosNeg_113;

            string xsltFile =
                FileUtil.ReadContentFromResource(datosNeg.ResourceFolder, datosNeg.XsltEngineToFormiikFileName);

            string engineRequirementtext =
                FileUtil.ReadContentFromResource(datosNeg.ResourceFolder, datosNeg.RequirementExampleFileName);

            var requirementAsJson =
                FormiikGenericParser.DeserializeFromJson<IncomeRequirementInfoDto>(engineRequirementtext);
            
            var transformRules = new TsRequirementTranformRule()
            {
                ClientId = TestConstants.FENG_CLIENT_ID,
                RuleId = datosNeg.ContanierId,
                ContainerId = datosNeg.ContanierId,
                XsltTransformation = xsltFile,
                FormInFormiik = TestConstants.NAME_FORM_FORMIIK
            };
           
            NewWorkOrder newOrderInFormiik =
                EngineToMobileTransformer.TransformToNewWorkOrder(requirementAsJson, transformRules);

            newOrderInFormiik.ParametersAsDictionary.TryGetValue("NomActEco", out string val);
            newOrderInFormiik.ParametersAsDictionary.TryGetValue("NomSecEco", out string val2);
            
            Assert.False(string.IsNullOrEmpty(val));
            Assert.False(string.IsNullOrEmpty(val2));
        }
    }
}