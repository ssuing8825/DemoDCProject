using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDCProject.Models
{
    public class PaymentAccounts
    {
        public List<CreditCard> CreditCards { get; set; }
        public List<CheckInfo> BankAccounts { get; set; }

    }
}