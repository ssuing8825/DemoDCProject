using DemoDCProject.DomainLayer.Gateways.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Payment
{
    internal abstract class PaymentGatewayBase
    {
        public string StoreCreditCardAtTokenProviders(string creditCard, string expirationDate)
        {
            ValidateTokenInformation(creditCard, expirationDate);
            return StoreCreditCardAtTokenProvidersCore(creditCard, expirationDate);
        }

        protected abstract string StoreCreditCardAtTokenProvidersCore(string creditCard, string expirationDate);

        private static void ValidateTokenInformation(string creditCard, string expirationDate)
        {
            Ensure(!string.IsNullOrEmpty(creditCard), "The creditCard property can not be null or empty");
            Ensure(!string.IsNullOrEmpty(expirationDate), "The expirationDate property can not be null or empty");

        }
        private static void Ensure(bool condition, string exceptionMessage)
        {
            if (!condition)
                throw new InvalidTokenInfomationException(exceptionMessage);
        }
    }
}
