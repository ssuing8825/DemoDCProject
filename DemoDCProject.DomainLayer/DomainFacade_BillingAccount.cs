using DemoDCProject.PublicDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer
{
    public sealed partial class DomainFacade
    {
        /// <summary>
        /// Stores the credit card information at the provider and generates a tokenNumber.
        /// </summary>
        /// <param name="creditCard"></param>
        /// <param name="expirationDate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AccountSummary>> RetrieveBillingAccountsByPolicyId(int policyId)
        {
            return await BillingAccountManager.RetrieveBillingAccountsForPolicyId(policyId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="policyId"></param>
        /// <returns></returns>
        public async Task<BillingAccountDetail> RetrieveBillingAccountDetailByPolicyId(int policyId)
        {
            return await BillingAccountManager.RetrieveBillingAccountDetailForPolicyId(policyId);
        }
    }

}
