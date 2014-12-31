using DemoDCProject.DomainLayer.Exceptions;
using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.PublicDto;
using DemoDCProject.Testing.Shared.TestMediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.Testing.Shared.Doubles.Fakes
{
    internal sealed class BillingGatewayFake : BillingGatewayBase
    {
        private readonly List<BillingAccountDetail> billingAccounts = new List<BillingAccountDetail>();

        private readonly List<AccountSummary> searchResults = new List<AccountSummary>();


        private readonly TestMediator testMediator;

        public BillingGatewayFake(TestMediator testMediator)
        {
            this.testMediator = testMediator;
            billingAccounts.Add(new BillingAccountDetail(10003, 5, 23.5m, "Active"));
            searchResults.Add(new AccountSummary(10003, 5));
        }

        protected override async Task<BillingAccountDetail> RetrieveBillingAccountDetailByAccountIdCore(int billingAccountId)
        {
            var result = billingAccounts.Where(c => c.AccountId == billingAccountId).FirstOrDefault();
            return result;
        }

        protected override async Task<IEnumerable<AccountSummary>> RetrieveBillingAccountsByPolicyIdCore(int policyId)
        {
            return searchResults;
        }

        protected override Task<BillingAccountDetail> RetrieveBillingAccountDetailByPolicyIdCore(int policyId)
        {
            throw new NotImplementedException();
        }
    }
}
