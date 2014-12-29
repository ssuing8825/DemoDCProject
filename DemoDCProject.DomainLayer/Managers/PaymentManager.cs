using DemoDCProject.DomainLayer.DataLayer;
using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.DomainLayer.Managers.Gateways.Payment;
using DemoDCProject.DomainLayer.Managers.Helpers;
using DemoDCProject.DomainLayer.Models.Domain;
using DemoDCProject.DomainLayer.Models.Public;
using DemoDCProject.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string StoreAndGenerateTokenForCreditCard(int billingAccountId, string creditCard, string expirationDate)
        {
            //Get the PEC from the billing providere
            var pec = PaymentGateway.StoreCreditCardAtTokenProviders(creditCard, expirationDate);

            //What do I do if the payment gateway is down.

            //Create a token for the end user. 
            var token = TokenProvider.GenerateToken();

            //Store both the token the PEC in the billing system
            BillingGateway.CreateCreditCardBillingPaymentMethod(billingAccountId, pec, token);

           //Now that I have a pec save it to the db with a new token
            DataFacade.CreateToken(new Token(pec, token));
            return token;

        }
        public AuthenticatedPaymentInformation AuthenticateCreditCardUsingTokenCore(string nameOnCard, string externalIdentifier, decimal amount, string token, string expirationdate)
        {
            throw new NotImplementedException();
        }
    }
}
