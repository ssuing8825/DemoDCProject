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
        private int accountId;
        public int AccountId { get { return accountId; } }

        private int accountReference;
        public int AccountReference { get { return accountReference; } }

        private int returnCount;
        public int ReturnCount { get { return returnCount; } }

        private AccountSearchResult() { }

        public static AccountSearchResult Fetch(string inputXml)
        {
            return Fetch(XElement.Parse(inputXml));
        }
        public static AccountSearchResult Fetch(XElement inputXml)
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
