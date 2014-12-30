using DemoDCProject.DomainLayer.Exceptions;
using DemoDCProject.DomainLayer.Models.Public;
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

        protected override void CreateCreditCardBillingPaymentMethodCore(int billingAccountId, string pec, string tokennumber)
        {
            throw new NotImplementedException();
        }

        //todo make this async
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


        protected override async Task<BillingAccountSummary> RetrieveBillingAccountSummaryByAccountIdCore(int billingAccountId)
        {
            //May need to call a search to make sure that the account exists before calling this one since the error is pretty ugly.
            string result = await CallDuckCreek(DuckCreekServiceCallFactory.GetAccountSummaryRequest(billingAccountId));
            //SHould check for exceptions like not found and throw
            return BillingAccountSummary.FetchBillingAccountSummary(result);
        }

        protected override async Task<AccountSearchResult> SearchForBillingAccountByPolicyIdCore(int policyId)
        {
            var formattedPolicyid = policyId.ToString().PadLeft(6, '0');

            //May need to call a search to make sure that the account exists before calling this one since the error is pretty ugly.
            string result = await CallDuckCreek(DuckCreekServiceCallFactory.SearchForAccountByPolicyId(formattedPolicyid));
            
            //Should check for exceptions like not found and throw
            return AccountSearchResult.Fetch(result);
        }

        protected override async Task<BillingAccountSummary> RetrieveBillingAccountSummaryByPolicyIdCore(int policyId)
        {
            var searchResult = await SearchForBillingAccountByPolicyIdCore(policyId);

            if (searchResult.ReturnCount == 0)
                throw new BillingAccountNotFoundException("A billing account for policy id " + policyId + " was not found");

            string result = await CallDuckCreek(DuckCreekServiceCallFactory.GetAccountSummaryRequest(searchResult.AccountId));
            //SHould check for exceptions like not found and throw
            return BillingAccountSummary.FetchBillingAccountSummary(result);
        }
    }
}
