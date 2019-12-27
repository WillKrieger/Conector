using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.TsEntity;
using Xunit;

namespace Formiik.Connector.ProcessorTests.FirstDelivery.FormiikToEngineTest.ConfigTest
{
    public class FlexibleUpdateResultConfigTests
    {
        [Fact]
        public void Configure_SpectedResponse_BusqCliente_Tests()
        {
            var configTable = new AzureTableStorage<TSFlexibleUpdateEngineResponsesConfig>(GeneralConstants.TS_FLEXIBLE_UPDATE_ENGINE_RESPONSES_CONFIG);
            
            var infoClienteyFam = TestConstants.InfoClienteFam_112;

            var busqCliente = TestConstants.BusqCliente_111;
            
            var searchCustomerFuConfig = new TSFlexibleUpdateEngineResponsesConfig()
            {
                ConfigId = $"{TestConstants.FENG_CLIENT_ID}_{busqCliente.ContanierId}",
                ExpectedContanierId = infoClienteyFam.ContanierId,
                ResponseIsRequired = true
            };

            configTable.Delete(searchCustomerFuConfig.ConfigId, searchCustomerFuConfig.ExpectedContanierId).Wait();

            configTable.Insert(searchCustomerFuConfig).Wait();
        }
    }
}