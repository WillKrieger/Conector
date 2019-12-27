using System;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Processor.MobileProxy;
using Formiik.Connector.ProcessorTests.TestEntities;
using Formiik.Connector.ProcessorTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Formiik.Connector.ProcessorTests.TercerSprintTest.EngineToMobileTest
{
    public class RequirementProcessorTests
    {
        #region - 01 Solicitud de Credito Normal -

        [Fact]
        public void SolCreNor_ProcessRequirement_Test()
        {
            ExecuteProcessRequirement(TercerSprintTestConstants.SolCreNor);
        }

        #endregion
        
        #region - 02 Evaluacion de Negocio -

        [Fact]
        public void TabEvaNeg_ProcessRequirement_Test()
        {
            ExecuteProcessRequirement(TercerSprintTestConstants.TabEvaNeg);
        }

        #endregion

        #region - 02 Evaluacion de Negocio -

        [Fact]
        public void TabDatNeg_ProcessRequirement_Test()
        {
            ExecuteProcessRequirement(TercerSprintTestConstants.TabDatNeg);
        }

        #endregion
        
        
        [Fact]
        public void CancelRequirement_Test()
        {
            ExecuteCancelRequirement(TercerSprintTestConstants.SolCreNor);
        }
        
        
        
        private void ExecuteProcessRequirement(TestEntityInfo testInfo)
        {
            try
            {
                IRequirementProcessor processor = new RequirementProcessor(TercerSprintTestConstants.ConstantesPrueba());
                
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

        private void ExecuteCancelRequirement(TestEntityInfo testInfo)
        {
            try
            {
                IRequirementProcessor processor = new RequirementProcessor(TercerSprintTestConstants.ConstantesPrueba());
                
                string searchInfoTxt =
                    FileUtil.ReadContentFromResource(testInfo.ResourceFolder,
                        testInfo.RequirementExampleFileName);
                
                var request = JsonConvert.DeserializeObject<IncomeInstanceCancelledDto>(searchInfoTxt);

                processor.ProcessInstanceCancellation(request).Wait();
            }
            catch (Exception e)
            {
                string message = $"CancelRequirement Fail: {testInfo.ContanierId}: {e.Message}";
                Assert.True(e == null, message);
            }
        }
    }
}