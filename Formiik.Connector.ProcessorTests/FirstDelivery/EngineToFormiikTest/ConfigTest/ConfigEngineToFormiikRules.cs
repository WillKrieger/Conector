using System.Collections.Generic;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.EngineToFormiikTest.ConfigTest
{

    /// <summary>
    /// hola mundo
    /// </summary>
    public class ConfigEngineToFormiikRules
    {
        [Fact]
        public void ConfigureRulesTransEngineToFormiik()
        {
            var tsXsltRules = new AzureTableStorage<TsRequirementTranformRule>(GeneralConstants.TS_XSLT_REQUIREMENTS_RULES);
            
            var rules = new List<TsRequirementTranformRule>();

            #region - client info 111 -
            
            var busqCliente = TestConstants.BusqCliente_111;
            
            string busquedaXslt = FileUtil.ReadContentFromResource(busqCliente.ResourceFolder, busqCliente.XsltEngineToFormiikFileName);
            
            var busqClienteRule = new TsRequirementTranformRule()
            {
                ClientId = TestConstants.FENG_CLIENT_ID,
                RuleId = busqCliente.ContanierId,
                ContainerId = busqCliente.ContanierId,
                XsltTransformation = busquedaXslt,
                FormInFormiik = TestConstants.NAME_FORM_FORMIIK_SOLICITUDASIGNADA,
                FormVersionInFormiik = TestConstants.NAME_FORM_VERSION_SOLICITUDASIGNADA,
                SectionId = busqCliente.SectionId,
                Description = busqCliente.XsltEngineToFormiikDescription
            };
            
            //rules.Add(busqClienteRule);
            
            #endregion
            
            #region - Info Fam 112-
            
            var infoCliente = TestConstants.InfoClienteFam_112;
            
            string infoClientXslt = FileUtil.ReadContentFromResource(infoCliente.ResourceFolder, infoCliente.XsltEngineToFormiikFileName);
            var infoClienteyFamRule_112 = new TsRequirementTranformRule()
            {
                ClientId = TestConstants.FENG_CLIENT_ID,
                RuleId =  infoCliente.ContanierId,
                ContainerId = infoCliente.ContanierId,
                XsltTransformation = infoClientXslt,
                FormInFormiik = TestConstants.NAME_FORM_FORMIIK_SOLICITUDASIGNADA,
                FormVersionInFormiik = TestConstants.NAME_FORM_VERSION_SOLICITUDASIGNADA,
                SectionId = infoCliente.SectionId,
                Description = infoCliente.XsltEngineToFormiikDescription
            };

            var dependencyFromDatosNeg = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_TOCONFIRM,
                // ContainerIdForUserAssignment = TestConstants.DatosNeg_113.ContanierId
            };

            var infoClienteyFamRuleStatusRules = new List<TransformRuleByRequirementStatus>();
            infoClienteyFamRuleStatusRules.Add(dependencyFromDatosNeg);
            
            infoClienteyFamRule_112.RulesApliedToStatusAsJson = FormiikGenericParser.SerializeToJson(infoClienteyFamRuleStatusRules);
            rules.Add(infoClienteyFamRule_112);
            #endregion
            
            #region - Datos de negocio: 113 -
            
            var datosNegInfo = TestConstants.DatosNeg_113;
            
            string infoDatosNegXslt = FileUtil.ReadContentFromResource(datosNegInfo.ResourceFolder, datosNegInfo.XsltEngineToFormiikFileName);
            
            var infoDatosNegRule = new TsRequirementTranformRule()
            {
                ClientId = TestConstants.FENG_CLIENT_ID,
                RuleId =  datosNegInfo.ContanierId,
                ContainerId = datosNegInfo.ContanierId,
                XsltTransformation = infoDatosNegXslt,
                FormInFormiik = TestConstants.NAME_FORM_FORMIIK_SOLICITUDASIGNADA,
                FormVersionInFormiik = TestConstants.NAME_FORM_VERSION_SOLICITUDASIGNADA,
                SectionId = datosNegInfo.SectionId,
                Description = datosNegInfo.XsltEngineToFormiikDescription
            };
            
            var infoDatosNegRuleRejected = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_REJECTED,
                ContainersWhomDependOn = new List<string>()
                {
                    TestConstants.InfoClienteFam_112.ContanierId,
                    TestConstants.Recomendacion_114.ContanierId,
                }
            };
            
            var negRuleOpen = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = EngineContainerStatus.CONTAINER_STATUS_OPEN,
                ContainersWhomDependOn = new List<string>()
                {
                    TestConstants.InfoClienteFam_112.ContanierId,
                    TestConstants.Recomendacion_114.ContanierId,
                }
            };

            var infoDatosNegRuleStatusRules = new List<TransformRuleByRequirementStatus>();
            infoDatosNegRuleStatusRules.Add(infoDatosNegRuleRejected);
            infoDatosNegRuleStatusRules.Add(negRuleOpen);
            infoDatosNegRule.RulesApliedToStatusAsJson = FormiikGenericParser.SerializeToJson(infoDatosNegRuleStatusRules);
            
            rules.Add(infoDatosNegRule);
            #endregion
            
            #region - Recomendacion 114-
            
            var recomendacion = TestConstants.Recomendacion_114;
            
            string recommendationXslt = FileUtil.ReadContentFromResource(recomendacion.ResourceFolder, recomendacion.XsltEngineToFormiikFileName);
            var recommendationRule = new TsRequirementTranformRule()
            {
                ClientId = TestConstants.FENG_CLIENT_ID,
                RuleId =  recomendacion.ContanierId,
                ContainerId = recomendacion.ContanierId,
                XsltTransformation = recommendationXslt,
                FormInFormiik = TestConstants.NAME_FORM_FORMIIK_SOLICITUDASIGNADA,
                FormVersionInFormiik = TestConstants.NAME_FORM_VERSION_SOLICITUDASIGNADA,
                SectionId = recomendacion.SectionId,
                Description = recomendacion.XsltEngineToFormiikDescription
            };
            
            rules.Add(recommendationRule);
                      
            #endregion
            
            foreach (var rule in rules)
            {
                tsXsltRules.Delete(rule.PartitionKey, rule.RowKey).Wait();
                
                tsXsltRules.Insert(rule).Wait();
            }
        }

    }
}