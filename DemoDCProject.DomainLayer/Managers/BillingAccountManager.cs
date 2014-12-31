using DemoDCProject.DomainLayer.Exceptions;
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
        public async Task<IEnumerable<AccountSummary>> RetrieveBillingAccountsForPolicyId(int policyId)
        {
            return await BillingGateway.RetrieveBillingAccountsByPolicyId(policyId);
        }
        public async Task<BillingAccountDetail> RetrieveBillingAccountDetailForPolicyId(int policyId)
        {
            var result = await BillingGateway.RetrieveBillingAccountDetailByAccountId(policyId);
            if (result == null)
                throw new BillingAccountNotFoundException();

            return result;
        }

    }
}
