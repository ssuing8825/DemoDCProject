using DemoDCProject.DomainLayer.Models.Public;
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

        public void CreateCreditCardBillingPaymentMethod(int billingAccountId, string pec, string tokennumber)
        {
            CreateCreditCardBillingPaymentMethodCore(billingAccountId, pec, tokennumber);
        }

        public async Task<BillingAccountSummary> RetrieveBillingAccountSummaryByAccountId(int billingAccountId)
        {
            return await RetrieveBillingAccountSummaryByAccountIdCore(billingAccountId);
        }

        public async Task<AccountSearchResult> SearchForBillingAccountByPolicyId(int policyId)
        {
            return await SearchForBillingAccountByPolicyIdCore(policyId);
        }

        protected abstract void CreateCreditCardBillingPaymentMethodCore(int billingAccountId, string pec, string tokennumber);
        protected abstract Task<BillingAccountSummary> RetrieveBillingAccountSummaryByAccountIdCore(int billingAccountId);
        protected abstract Task<IEnumerable<BillingAccountSummary>> SearchForBillingAccountByPolicyIdCore(int policyId);
    }
}
