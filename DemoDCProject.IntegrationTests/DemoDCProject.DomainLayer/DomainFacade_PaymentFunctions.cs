using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoDCProject.DomainLayer.Gateways.Payment;

namespace DemoDCProject.IntegrationTests
{
    [TestClass]
    public class DomainFacade_PaymentFunctions : EndToEndIntegrationTestsBase
    {
        const string CREDITCARD = "4111111111111111";
        const string FULLNAME = "Steve Suing";
        const string EXPDATE = "1018";


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
        public void DomainFacade_StoreCreditCard_WithValidParameters_ShouldSucceed()
        {
            // Arrange
            // Nothing to arrange here. We might set up an account or prep the database

            // Act
            var token = domainFacadeUnderTest.StoreCreditCardInformation(1, CREDITCARD, EXPDATE);

            // Assert
            Assert.AreEqual(1, testMediator.StoreCreditCardVerificationNumberCountOfCreditCardsSent);

            // Should be able to Get this tokenNumber out of the 
            //     var tokenNumber = domainFacadeUnderTest.StoreCreditCardInformation(CREDITCARD, EXPDATE);

            // Should be able to verify token is stored in DuckCreek. 
            //     var tokenNumber = domainFacadeUnderTest.StoreCreditCardInformation(CREDITCARD, EXPDATE);

        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void DomainFacade_StoreCreditCard_WithBlankCreditCard_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.StoreCreditCardInformation(1, string.Empty, EXPDATE);
        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void DomainFacade_StoreCreditCard_WithNullCreditCard_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.StoreCreditCardInformation(1, null, EXPDATE);
        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void DomainFacade_StoreCreditCard_WithNullExpDate_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.StoreCreditCardInformation(1, CREDITCARD, null);
        }

    }
}
