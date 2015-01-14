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
        public string StoreCreditCardAtTokenProviders(string creditCard, int expirationMonth, int expirationYear)
        {
            ValidateTokenInformation(creditCard, expirationMonth, expirationYear);
            return StoreCreditCardAtTokenProvidersCore(creditCard, expirationMonth, expirationYear);
        }

        protected abstract string StoreCreditCardAtTokenProvidersCore(string creditCard, int expirationMonth, int expirationYear);

        private static void ValidateTokenInformation(string creditCard, int expirationMonth, int expirationYear)
        {
            Ensure(!string.IsNullOrEmpty(creditCard), "The creditCard property can not be null or empty");
            Ensure(!(expirationMonth == 0), "The expirationDate property can not be null or empty");

        }
        private static void Ensure(bool condition, string exceptionMessage)
        {
            if (!condition)
                throw new InvalidTokenInfomationException(exceptionMessage);
        }
    }
}
