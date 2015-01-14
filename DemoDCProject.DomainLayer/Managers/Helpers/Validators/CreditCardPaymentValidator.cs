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
        public static void Validate(string externalIdentifier, string creditcard, int expirationMonth, int expirationYear)
        {
            if (string.IsNullOrEmpty(externalIdentifier))
                throw new CreditCardPaymentInformationException("The external identifier must be provided and cannot be null or empty");

            if (expirationMonth <= 0 || expirationMonth > 12)
                throw new CreditCardPaymentInformationException("The month of the credit card must be between 1 and 12");

            //TODO Validate Credit Card

            //TODO Validate the Year and month combination in relation to the current month and year.
            //if (expirationYear)
            //    throw new CreditCardPaymentInformationException("The token for the payment must be provided and cannot be null or empty");
        }
    }
}
