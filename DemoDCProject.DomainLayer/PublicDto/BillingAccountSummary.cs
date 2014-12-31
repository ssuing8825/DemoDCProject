using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoDCProject.PublicDto
{
    public sealed class BillingAccountDetail
    {
        private readonly int accountId;
        public int AccountId { get { return accountId; } }

        private readonly  int accountReference;
        public int AccountReference { get { return accountReference; } }

        private readonly decimal pastDueAmount;
        public decimal PastDueAmount { get { return pastDueAmount; } }

        private readonly  string accountStatus;
        public string AccountStatus { get { return accountStatus; } }

        private BillingAccountDetail() { }
        public  BillingAccountDetail(int accountId, int accountReference, decimal pastDueAmount, string accountStatus)
        {
            this.accountId = accountId;
            this.accountReference = accountReference;
            this.pastDueAmount = pastDueAmount;
            this.accountStatus = accountStatus;
        }
    }
}
