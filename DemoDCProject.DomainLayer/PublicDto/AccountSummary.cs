using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoDCProject.PublicDto
{
    public sealed class AccountSummary
    {
        //This class is immutable
        private readonly int accountId;
        public int AccountId { get { return accountId; } }

        private readonly int accountReference;
        public int AccountReference { get { return accountReference; } }

        public AccountSummary(int accountId, int accountReference)
        {
            this.accountId = accountId;
            this.accountReference = accountReference;
        }
    }
}
