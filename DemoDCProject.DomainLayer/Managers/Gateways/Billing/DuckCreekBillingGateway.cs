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
        public string CallDuckCreek(string request)
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
                var resp = httpClient.SendAsync(req).Result;
                return resp.Content.ReadAsStringAsync().Result;
            }
        }

    }
}
