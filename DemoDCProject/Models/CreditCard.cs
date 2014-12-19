using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDCProject.Models
{
    public class CreditCard : AccountBase
    {
        public string CreditCardNumber { get; set; }
        public string VerificationCode { get; set; }
        public string ExpDate { get; set; }
        public string Token { get; set; }
    }
}