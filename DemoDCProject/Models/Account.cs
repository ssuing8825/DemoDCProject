using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDCProject.Models
{
    public class Account
    {
     
        public int AccountId { get; set; }
        public String AccountReference { get; set; }
        public decimal PastDueAmount { get; set; }
        public decimal AccountStatus { get; set; }

      

     

    }
}