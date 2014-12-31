using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoDCProject.DomainLayer.Models.Public
{
    public sealed class BillingAccountSummary
    {
        private int accountId;
        public int AccountId { get { return accountId; } }

        private int accountReference;
        public int AccountReference { get { return accountReference; } }

        private decimal pastDueAmount;
        public decimal PastDueAmount { get { return pastDueAmount; } }

        private string accountStatus;
        public string AccountStatus { get { return accountStatus; } }

        private BillingAccountSummary() { }

        public static BillingAccountSummary Fetch(string inputXml)
        {
            return Fetch(XElement.Parse(inputXml));
        }
        public static BillingAccountSummary Fetch(XElement inputXml)
        {
            var result = new BillingAccountSummary();
            result.accountId = int.Parse(inputXml.Descendants("AccountId").First().Value);
            result.accountReference = int.Parse(inputXml.Descendants("AccountReference").First().Value);
            result.pastDueAmount = decimal.Parse(inputXml.Descendants("PastDueAmount").First().Value);
            result.accountStatus = inputXml.Descendants("AccountStatus").First().Value;
            return result;
        }
    }
}
