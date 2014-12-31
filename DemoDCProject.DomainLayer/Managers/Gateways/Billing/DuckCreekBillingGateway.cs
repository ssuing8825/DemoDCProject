using DemoDCProject.DomainLayer.Exceptions;
using DemoDCProject.PublicDto;
using DemoDCProject.DomainLayer.ServiceLocator;
using DemoDCProject.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Billing
{
    internal sealed class DuckCreekBillingGateway : BillingGatewayBase
    {
        private readonly ServiceLocatorBase serviceLocator;
        private ConfigurationProviderBase configurationProvider;
        public ConfigurationProviderBase ConfigurationProvider { get { return configurationProvider ?? (configurationProvider = serviceLocator.CreateConfigurationProvider()); } }

        public DuckCreekBillingGateway(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }
 
        private async Task<string> CallDuckCreek(string request)
        {
            using (var httpClient = new HttpClient())
            {
                var req = new HttpRequestMessage
                {
                    RequestUri = new Uri(ConfigurationProvider.DuckCreekUrl),
                    Method = HttpMethod.Post,
                    Content = new StringContent(request, Encoding.UTF8, "application/xml")
                };
                //   req.Headers.Add("Authorization", "Basic " + ConfigurationManager.AppSettings["AzureAuth"]);
                var resp = await httpClient.SendAsync(req);
                return await resp.Content.ReadAsStringAsync();
            }
        }


        protected override async Task<BillingAccountDetail> RetrieveBillingAccountDetailByAccountIdCore(int billingAccountId)
        {
            //May need to call a search to make sure that the account exists before calling this one since the error is pretty ugly.
            string result = await CallDuckCreek(DuckCreekServiceCallFactory.GetAccountSummaryRequest(billingAccountId));

            //Should check for exceptions like not found and throw
            return BillingAccountDetailMapper.FromXml(result);
        }

        protected override async Task<IEnumerable<AccountSummary>> RetrieveBillingAccountsByPolicyIdCore(int policyId)
        {
            var formattedPolicyid = policyId.ToString().PadLeft(6, '0');
            string result = await CallDuckCreek(DuckCreekServiceCallFactory.SearchForAccountByPolicyId(formattedPolicyid));

            //Should check for exceptions like not found and throw
            return BillingAccountSearchToBillingAccountsSummary.FromXml(result);
        }

        protected override async Task<BillingAccountDetail> RetrieveBillingAccountDetailByPolicyIdCore(int policyId)
        {
            var billingAccountsForPolicyNumber = await RetrieveBillingAccountsByPolicyId(policyId);
            if (billingAccountsForPolicyNumber.Count() == 0)
                return null;

            return await RetrieveBillingAccountDetailByAccountId(billingAccountsForPolicyNumber.First().AccountId);
        }
    }
}
