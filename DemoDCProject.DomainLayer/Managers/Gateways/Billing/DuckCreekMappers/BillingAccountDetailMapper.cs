using DemoDCProject.PublicDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Billing
{
    internal static class BillingAccountDetailMapper
    {
        //Maps from return results to DTO Classess
       internal static BillingAccountDetail FromXml(string inputXml)
        {
            //TODO Do a performance test to see the difference in the performance between XmlDocument and XElement. If the time is negligible don't 
            // worry about it.

            var inputXmlElement = XElement.Parse(inputXml);

            var accountId = int.Parse(inputXmlElement.Descendants("AccountId").First().Value);
            var accountReference = int.Parse(inputXmlElement.Descendants("AccountReference").First().Value);
            var pastDueAmount = decimal.Parse(inputXmlElement.Descendants("PastDueAmount").First().Value);
            var accountStatus = inputXmlElement.Descendants("AccountStatus").First().Value;

            return new BillingAccountDetail(accountId, accountReference, pastDueAmount, accountStatus);
        }


    }
}
