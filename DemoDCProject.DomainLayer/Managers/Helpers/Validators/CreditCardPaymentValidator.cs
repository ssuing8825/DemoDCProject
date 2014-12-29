using DemoDCProject.DomainLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Validators
{
    internal static class CreditCardPaymentValidator
    {
        public static void Validate(string nameOnCard, string externalIdentifier, decimal amount, string token, string expirationdate)
        {
            if (string.IsNullOrEmpty(nameOnCard))
                throw new CreditCardPaymentInformationException("The name on the creditcard must be provided and cannot be null or empty");

            if (string.IsNullOrEmpty(externalIdentifier))
                throw new CreditCardPaymentInformationException("The external identifier must be provided and cannot be null or empty");

            if (amount <= 0)
                throw new CreditCardPaymentInformationException("The amount of the payment must be provided and must be greater that 0");

            if (string.IsNullOrEmpty(token))
                throw new CreditCardPaymentInformationException("The token for the payment must be provided and cannot be null or empty");
        }
    }
}
