using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.DomainLayer.Models.Public;
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
        private readonly TestMediator testMediator;

        public BillingGatewayFake(TestMediator testMediator)
        {
            this.testMediator = testMediator;
        }

        protected override void CreateCreditCardBillingPaymentMethodCore(int billingAccountId, string pec, string tokennumber)
        {
            throw new NotImplementedException();
        }

        protected override Task<BillingAccountSummary> RetrieveBillingAccountSummaryByAccountIdCore(int billingAccountId)
        {
            throw new NotImplementedException();
        }

        protected override Task<AccountSearchResult> SearchForBillingAccountByPolicyIdCore(int policyId)
        {
            throw new NotImplementedException();
        }

        protected override Task<BillingAccountSummary> RetrieveBillingAccountSummaryByPolicyIdCore(int policyId)
        {
            throw new NotImplementedException();
        }
    }
}
