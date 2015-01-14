using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoDCProject.DomainLayer.Gateways.Payment;
using DemoDCProject.DomainLayer.Exceptions;

namespace DemoDCProject.IntegrationTests
{
    [TestClass]
    public class DomainFacade_PaymentFunctions : EndToEndIntegrationTestsBase
    {
        const string CREDITCARD = "4111111111111111";
        const string FULLNAME = "Steve Suing";
        const int EXPMONTH = 10;
        const int EXPYEAR = 18;


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
            string token = string.Empty;
            try
            {
                // Act
                token = domainFacadeUnderTest.StoreCreditCardInformation(1, CREDITCARD, EXPMONTH, EXPYEAR);

                // Assert
                Assert.AreEqual(1, testMediator.StoreCreditCardVerificationNumberCountOfCreditCardsSent);

                // Should be able to Get this tokenNumber out of the 
                //     var tokenNumber = domainFacadeUnderTest.StoreCreditCardInformation(CREDITCARD, EXPDATE);

                // Should be able to verify token is stored in DuckCreek. 
                //     var tokenNumber = domainFacadeUnderTest.StoreCreditCardInformation(CREDITCARD, EXPDATE);
          
            }
            finally
            {
                  //cleanup
                domainFacadeUnderTest.DeleteTokenWithTokenNumber(token);
            }
  
    

        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void DomainFacade_StoreCreditCard_WithBlankCreditCard_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.StoreCreditCardInformation(1, string.Empty, EXPMONTH, EXPYEAR);
        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(InvalidTokenInfomationException))]
        public void DomainFacade_StoreCreditCard_WithNullCreditCard_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.StoreCreditCardInformation(1, null, EXPMONTH, EXPYEAR);
        }

        [TestMethod]
        [TestCategory("End-to-End Integration Test")]
        [ExpectedException(typeof(CreditCardPaymentInformationException))]
        public void DomainFacade_StoreCreditCard_WithZeroExpDate_ShouldThrow()
        {
            // Act
            var token = domainFacadeUnderTest.StoreCreditCardInformation(1, CREDITCARD, 0, 0);
        }

    }
}
