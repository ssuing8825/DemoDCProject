using DemoDCProject.PublicDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Billing
{
    internal static class BillingAccountSearchToBillingAccountsSummary
    {
        internal static IEnumerable<AccountSummary> FromXml(string inputXml)
        {
            //TODO Do a performance test to see the difference in the performance between XmlDocument and XElement. If the time is negligible don't 
            // worry about it.

            var inputXmlElement = XElement.Parse(inputXml);

            //there is a way to do this with linq in one line but then I can't go to XmlDocument if I want.
            var accountsXml = inputXmlElement.Descendants("ItemData");
            var result = new List<AccountSummary>();

            foreach (XElement item in accountsXml)
            {
                result.Add(new AccountSummary(
                       int.Parse(inputXmlElement.Descendants("AccountId").First().Value),
                       int.Parse(inputXmlElement.Descendants("AccountReference").First().Value)
                    ));
            }

            return result;
        }

    }
}
