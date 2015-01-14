using System;
namespace DemoDCProject.DomainLayer
{
    public interface IDomainFacade
    {
        System.Threading.Tasks.Task<DemoDCProject.PublicDto.BillingAccountDetail> RetrieveBillingAccountDetailByPolicyId(int policyId);
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<DemoDCProject.PublicDto.AccountSummary>> RetrieveBillingAccountsByPolicyId(int policyId);
        string StoreCreditCardInformation(int billingAccountId, string creditCard, int expirationMonth, int expirationYear);
    }
}
