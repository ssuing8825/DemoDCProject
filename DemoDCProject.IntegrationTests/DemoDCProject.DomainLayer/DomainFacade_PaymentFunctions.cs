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
        public void CreateToken_WithValidParameters_ShouldSucceed()
        {
            // Arrange
            // Nothing to arrange here. We might set up an account or prep the database

            // Act
            var token = domainFacadeUnderTest.GenerateTokenAndStoreCreditCardInformation(CREDITCARD, EXPDATE);

            // Assert
            Assert.AreEqual(1, testMediator.MakePaymentVerificationNumberCountOfPaymentsSent);

            //Should be able to Get this token out of the 
            //     var token = domainFacadeUnderTest.GenerateTokenAndStoreCreditCardInformation(CREDITCARD, EXPDATE);

        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void CreateToken_WithBlankCreditCard_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.GenerateTokenAndStoreCreditCardInformation(string.Empty, EXPDATE);
        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void CreateToken_WithNullCreditCard_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.GenerateTokenAndStoreCreditCardInformation(null, EXPDATE);
        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void CreateToken_WithNullExpDate_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.GenerateTokenAndStoreCreditCardInformation(CREDITCARD, null);
        }

    }
}
