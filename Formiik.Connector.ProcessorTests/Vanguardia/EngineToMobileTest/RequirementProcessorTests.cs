using System;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Processor.MobileProxy;
using Formiik.Connector.ProcessorTests.TercerSprintTest;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.Vanguardia.EngineToMobileTest
{
    public class RequirementProcessorTests
    {
        #region - 01 Solicitud de Credito Normal -

        [Fact]
        public void SolCreNor_ProcessRequirement_Test()
        {
            ExecuteProcessRequirement(VanguardiaTestConstants.FirstRule);
        }

        [Fact]
        public void SecondRule_ProcessRequirement_Test()
        {
            ExecuteProcessRequirement(VanguardiaTestConstants.SecondRule);
        }
        
        #endregion
        private void ExecuteProcessRequirement(TestEntityInfo testInfo)
        {
            try
            {
                IRequirementProcessor processor = new RequirementProcessor(VanguardiaTestConstants.ConstantesPrueba());
                
                string searchInfoTxt =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder,
                        testInfo.RequirementExampleFileName);

                var request = JsonConvert.DeserializeObject<IncomeRequirementInfoDto>(searchInfoTxt);

                processor.ProcessRequirementReceived(request).Wait();
            }
            catch (Exception e)
            {
                string message = $"ProcessRequirementReceived Fail: {testInfo.SectionId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }
    }
}