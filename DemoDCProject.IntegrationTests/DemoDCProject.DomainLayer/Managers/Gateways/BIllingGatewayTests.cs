using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.Testing.Shared.ServiceLocator;
using DemoDCProject.ServiceProviders;
using System.Threading.Tasks;
using DemoDCProject.DomainLayer.Exceptions;

namespace DemoDCProject.IntegrationTests.DemoDCProject.DomainLayer.Managers.Gateways
{
    [TestClass]
    public class BillingGatewayTests
    {
        private static ServiceLocatorUnitTesting serviceLocator;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            serviceLocator = new ServiceLocatorUnitTesting();
            serviceLocator.ConfigurationProviderFactory = () => new ConfigurationProviderLocal();
        }

        [TestMethod]
        [Priority(-1)]
        [TestCategory("Class Integration Test")]
        public async Task BillingGateway_RetrieveABillingAccountByAccountIdAndHydrateObject()
        {
            //Arrange
            //Would Need to Create the account first and then retrieve it

            //Act
            BillingGatewayBase billingGateway = new DuckCreekBillingGateway(serviceLocator);
            var billingAccount = await billingGateway.RetrieveBillingAccountSummaryByAccountId(10003);

            //Assert.

        }

        [TestMethod]
        [Priority(-1)]
        [TestCategory("Class Integration Test")]
        public async Task BillingGateway_RetrieveABillingAccountByPolicyNumberAndHydrateObject()
        {
            //Arrange
            //Would Need to Create the account first and then retrieve it

            //Act
            BillingGatewayBase billingGateway = new DuckCreekBillingGateway(serviceLocator);
            var billingAccount = await billingGateway.RetrieveBillingAccountSummaryByPolicyId(5);

            //Assert.

        }

        [TestMethod]
        [Priority(-1)]
        [TestCategory("Class Integration Test")]
        [ExpectedException(typeof(BillingAccountNotFoundException))]
        public async Task BillingGateway_RetrieveABillingAccountByPolicyNumber_NotFound()
        {
            //Arrange
            //Would Need to Create the account first and then retrieve it

            //Act
            BillingGatewayBase billingGateway = new DuckCreekBillingGateway(serviceLocator);
            var billingAccount = await billingGateway.RetrieveBillingAccountSummaryByPolicyId(0);

            //Assert.

        }
    }
}
