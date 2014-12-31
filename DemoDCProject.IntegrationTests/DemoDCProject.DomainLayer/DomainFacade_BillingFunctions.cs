using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoDCProject.DomainLayer.Gateways.Payment;
using DemoDCProject.DomainLayer.Exceptions;
using System.Threading.Tasks;

namespace DemoDCProject.IntegrationTests
{
    [TestClass]
    public class DomainFacade_BillingFunctions : EndToEndIntegrationTestsBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Initialize(testContext);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            testMediator.Reset();

        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        public void RetrieveBillingAccountUsingPolicyNumber_ShouldSucceed()
        {
            // Arrange
            // Nothing to arrange here. Fake is already set.

            // Act
            var billingAccount = domainFacadeUnderTest.RetrieveBillingAccountByPolicyId(5);

            // Assert
            Assert.IsNotNull(billingAccount);
        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(BillingAccountNotFoundException))]
        public async Task RetrieveBillingAccountUsingPolicyNumber_PolicyIdNotFound()
        {
            // Arrange
            // Nothing to arrange here. Fake is already set.

            // Act
            var billingAccount = await domainFacadeUnderTest.RetrieveBillingAccountByPolicyId(3);

        }
    }
}
