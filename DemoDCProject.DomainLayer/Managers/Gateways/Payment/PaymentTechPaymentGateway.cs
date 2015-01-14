using DemoDCProject.DomainLayer.ServiceLocator;
using DemoDCProject.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Payment
{
    internal sealed class PaymentTechPaymentGateway : PaymentGatewayBase
    {
        private readonly ServiceLocatorBase serviceLocator;

        private ConfigurationProviderBase configurationProvider;
        public ConfigurationProviderBase ConfigurationProvider { get { return configurationProvider ?? (configurationProvider = serviceLocator.CreateConfigurationProvider()); } }

        private string paymentTechUrl;

        public PaymentTechPaymentGateway(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
          }
        protected override string StoreCreditCardAtTokenProvidersCore(string creditCard, int expirationMonth, int expirationYear)
        {
            //This is where the real work of calling paymenttech would go.
            //ConfigurationProvider.PaymentechUrl

            //if this fails log and throw an exception
            throw new NotImplementedException();
        }
    }
}
