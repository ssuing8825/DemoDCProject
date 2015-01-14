using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.DomainLayer.Managers.Gateways.Payment;
using DemoDCProject.DomainLayer.Managers.Helpers;
using DemoDCProject.PublicDto;
using DemoDCProject.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoDCProject.DomainLayer.Managers.DataLayer;
using DemoDCProject.DomainLayer.Managers.InternalDto;
using DemoDCProject.DomainLayer.Managers.Validators;

namespace DemoDCProject.DomainLayer.Managers
{
    internal sealed class PaymentManager
    {
        private readonly ServiceLocatorBase serviceLocator;

        private PaymentGatewayBase paymentGateway;
        private PaymentGatewayBase PaymentGateway { get { return paymentGateway ?? (paymentGateway = serviceLocator.CreatePaymentGateway()); } }

        private TokenGeneratorBase tokenProvider;
        private TokenGeneratorBase TokenProvider { get { return tokenProvider ?? (tokenProvider = serviceLocator.CreateTokenProvider()); } }

        private BillingGatewayBase billingGateway;
        private BillingGatewayBase BillingGateway { get { return billingGateway ?? (billingGateway = serviceLocator.CreateBillingGateway()); } }

        private DataFacade dataFacade;
        private DataFacade DataFacade { get { return dataFacade ?? (dataFacade = serviceLocator.CreateDataFacade()); } }

        public PaymentManager(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        /// <summary>
        ///    This method will store the credit card and return a token that can be used outside the billing system
        /// </summary>
        /// <param name="billingAccountId"></param>
        /// <param name="creditCard"></param>
        /// <param name="expirationDate"></param>
        /// <returns></returns>
        public string StoreCreditCard(int billingAccountId, string creditCard, int expirationMonth, int expirationYear)
        {

            CreditCardPaymentValidator.Validate(billingAccountId.ToString(), creditCard, expirationMonth, expirationYear);

            //Method name must be business specific. 

            //Create a tokenNumber for the end user. 
            var tokenNumber = TokenProvider.GenerateToken();

            //Store Billing account and token.


            //I could put the rest on the queue for processing because I can't do anything else
            //Then the other process will update DC and get the PEC and handle failures.
            //That would give me autmatice retry.  Would need to encrypt CC# for that.  

            //Get the PEC from the billing providere
            var pec = PaymentGateway.StoreCreditCardAtTokenProviders(creditCard, expirationMonth, expirationYear);

            //Need to expect a specific exception and catch and handle it.


            //What do I do if the payment gateway is down.



            //Store both the tokenNumber the PEC in the billing system
            //BillingGateway.CreateCreditCardBillingPaymentMethod(billingAccountId, pec, tokenNumber);

            //Now that I have a pec save it to the db with a new tokenNumber
            DataFacade.CreateToken(new Token(pec, tokenNumber));
            return tokenNumber;

        }
        public AuthenticatedPaymentInformation AuthenticateCreditCardUsingTokenCore(string nameOnCard, string externalIdentifier, decimal amount, string token, string expirationdate)
        {
            throw new NotImplementedException();
        }
        public void DeleteTokenWithTokenNumber(string tokenNumber)
        {
            DataFacade.DeleteTokenWithTokenNumber(tokenNumber);
        }
    }
}
