using System;
using System.Collections.Generic;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Processor.ConnectorStorage;
using Formiik.Connector.Processor.Utils;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FdlmTest.EngineToMobileTest
{
    public class ConfigRulesEngineToMobile
    {
         #region - 01 Pre Evaluacion (PesPreEva) -

        [Fact]
        public void PesPreEva_WriteRuleConfig_Test()
        {
//            var dependency = new TransformRuleByRequirementStatus()
//            {
//                ExpectedStatus = EngineContainerStatus.CONTAINER_STATUS_TOCONFIRM,
//                ContainerIdForUserAssignment = TestConstants.DatosNeg_113.ContanierId
//            };
//
//            var infoClienteyFamRuleStatusRules = new List<TransformRuleByRequirementStatus>();
//            infoClienteyFamRuleStatusRules.Add(dependencyFromDatosNeg);
            
            WriteRule(FdlmTestConstants.PesPreEva);
        }

        #endregion

        #region - 03 Pre-solicitud (PesPreSol) -

        [Fact]
        public void PesPreSol_WriteRuleConfig_Test()
        {
            //  f505 = 3, custom status, status
            var dependency = new TransformRuleByRequirementStatus()
            {
                ExpectedCustomStatus = 1,    
                ExpecterStatusContainer = EngineContainerStatus.CONTAINER_STATUS_OPEN,
                ContainersWhomDependOn = new List<string>() {FdlmTestConstants.PesPreEva.ContanierId}
            };

            var statusRules = new List<TransformRuleByRequirementStatus>();
            statusRules.Add(dependency);

            WriteRule(FdlmTestConstants.PesPreSol, statusRules);
        }

        #endregion
//
//        #region - 04 Análisis (PesAnaSol) -
//
//        [Fact]
//        public void PesAnaSol_WriteRuleConfig_Test()
//        {
//            WriteRule(FdlmTestConstants.PesAnaSol);
//        }
//
//        #endregion
//
//        #region - 05 Toma de Información del Negocio (TomInfBal) -
//
//        [Fact]
//        public void TomInfBal_WriteRuleConfig_Test()
//        {
//            WriteRule(FdlmTestConstants.TomInfBal);
//        }
//
//        #endregion
//
//        #region - 06 Referencias, codeudores y garantías (PesCodGar) -
//
//        [Fact]
//        public void PesCodGar_WriteRuleConfig_Test()
//        {
//            WriteRule(FdlmTestConstants.PesCodGar);
//        }
//
//        #endregion
//
//        #region - 07 Pólizas (PesPol) -
//
//        [Fact]
//        public void PesPol_WriteRuleConfig_Test()
//        {
//            WriteRule(FdlmTestConstants.PesPol);
//        }
//
//        #endregion
//
//        #region - 08 Evaluación (PesEva) -
//
//        [Fact]
//        public void PesEva_WriteRuleConfig_Test()
//        {
//            WriteRule(FdlmTestConstants.PesEva);
//        }
//
//        #endregion
//
//        #region - 09 Recomendación (PesRec) -
//
//        [Fact]
//        public void PesRec_WriteRuleConfig_Test()
//        {
//            WriteRule(FdlmTestConstants.PesRec);
//        }
//
//        #endregion

        #region- Write Mobile to Engine rules -

        private void WriteRule(TestEntityInfo testInfo, List<TransformRuleByRequirementStatus> customStatusRules = null)
        {
            try
            {
                string infoClientXslt = FileUtil.ReadContentFromResource(testInfo.ResourceFolder, testInfo.XsltEngineToFormiikFileName);
                
                var rule = new TsRequirementTranformRule()
                {
                    ClientId = testInfo.FormiikClientId,
                    ProductId = testInfo.ProductId,
                    DefinitionId = testInfo.DefinitionId,
                    ContainerId = testInfo.ContanierId,
                    XsltTransformation = infoClientXslt,
                    FormInFormiik = testInfo.FormName,
                    FormVersionInFormiik = testInfo.FormVersion,
                    SectionId = testInfo.SectionId,
                    Description = testInfo.XsltEngineToFormiikDescription,
                    HoursAddToCancellationDate = testInfo.HoursAddToCancellationDate,
                    HoursAddToExpirationDate = testInfo.HoursAddToExpirationDate,
                    TenantId = testInfo.EngineTenantId
                };

                if (customStatusRules != null && customStatusRules.Count > 0)
                {
                    rule.RulesApliedToStatusAsJson = FormiikGenericParser.SerializeToJson(customStatusRules);    
                }

                TransformationRulesStorage.SaveRuleEngineToMobile(testInfo.ContanierId, rule).Wait();
            }
            catch (Exception e)
            {
                string message = $"Fail write rule Engine => Formiik: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }

        #endregion
    }
}