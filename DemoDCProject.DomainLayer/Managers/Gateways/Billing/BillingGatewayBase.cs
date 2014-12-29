using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Billing
{
     internal abstract class BillingGatewayBase
    {
        public void CreateCreditCardBillingPaymentMethod(int billingAccountId, string pec, string tokennumber)
        {
             CreateCreditCardBillingPaymentMethodCore(billingAccountId, pec, tokennumber);

        }

        protected abstract void CreateCreditCardBillingPaymentMethodCore(int billingAccountId, string pec, string tokennumber);
    }
}
