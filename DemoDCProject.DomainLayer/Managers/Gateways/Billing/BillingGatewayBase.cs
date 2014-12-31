using DemoDCProject.PublicDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Billing
{
    internal abstract class BillingGatewayBase
    {

        //THis is abstracting the service the way we want to use. 


        public async Task<BillingAccountDetail> RetrieveBillingAccountDetailByAccountId(int billingAccountId)
        {
            return await RetrieveBillingAccountDetailByAccountIdCore(billingAccountId);
        }

        public async Task<IEnumerable<AccountSummary>> RetrieveBillingAccountsByPolicyId(int policyId)
        {
            return await RetrieveBillingAccountsByPolicyIdCore(policyId);
        }

        public async Task<BillingAccountDetail> RetrieveBillingAccountDetailByPolicyId(int policyId)
        {
            return await RetrieveBillingAccountDetailByPolicyIdCore(policyId);
        }

        protected abstract Task<BillingAccountDetail> RetrieveBillingAccountDetailByAccountIdCore(int billingAccountId);
        protected abstract Task<IEnumerable<AccountSummary>> RetrieveBillingAccountsByPolicyIdCore(int policyId);
        protected abstract Task<BillingAccountDetail> RetrieveBillingAccountDetailByPolicyIdCore(int policyId);

    }
}
