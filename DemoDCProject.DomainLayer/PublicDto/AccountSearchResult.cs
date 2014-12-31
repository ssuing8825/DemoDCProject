using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoDCProject.DomainLayer.Models.Public
{
    public sealed class AccountSearchResult
    {
        //TODO make this immutable bu adding the readonly attribute
        private readonly int accountId;
        public int AccountId { get { return accountId; } }

        private int accountReference;
        public int AccountReference { get { return accountReference; } }

        private int returnCount;
        public int ReturnCount { get { return returnCount; } }

        private AccountSearchResult() { }
        public AccountSearchResult(int accountId, int accountReference, int returnCount)
        {
            this.accountId = accountId;
            this.accountReference = returnCount;
            this.returnCount = returnCount;
        }


        public AccountSearchResult(string inputXml)
            : this(XElement.Parse(inputXml))
        {

        }

        //TODO need to move to a mapping class to isolate it. 
        // Also this class would be removed because the search would just return a list of billing accounts.
        public AccountSearchResult(XElement inputXml)
        {
            var result = new AccountSearchResult();
            result.returnCount = int.Parse(inputXml.Descendants("ReturnCount").First().Value);

            if (result.returnCount > 0)
            {
                result.accountId = int.Parse(inputXml.Descendants("AccountId").First().Value);
                result.accountReference = int.Parse(inputXml.Descendants("AccountReference").First().Value);

            }
            return result;
        }
    }
}
