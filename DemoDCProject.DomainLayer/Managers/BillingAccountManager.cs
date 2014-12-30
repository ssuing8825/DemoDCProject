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
    internal sealed class BillingAccountManager
    {
        private readonly ServiceLocatorBase serviceLocator;

        private BillingGatewayBase billingGateway;
        private BillingGatewayBase BillingGateway { get { return billingGateway ?? (billingGateway = serviceLocator.CreateBillingGateway()); } }

        public BillingAccountManager(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }
        public async Task<BillingAccountSummary> RetrieveBillingAccountForPolicyId(int policyId)
        {
            return await BillingGateway.RetrieveBillingAccountSummaryByPolicyId(policyId);
        }

        public AuthenticatedPaymentInformation AuthenticateCreditCardUsingTokenCore(string nameOnCard, string externalIdentifier, decimal amount, string token, string expirationdate)
        {
            throw new NotImplementedException();
        }
    }
}
