﻿using System;
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
        public string GenerateTokenAndStoreCreditCardInformation(int billingAccountId, string creditCard, string expirationDate)
        {
            return PaymentManager.StoreAndGenerateTokenForCreditCard(billingAccountId, creditCard, expirationDate);
        }
    }

}