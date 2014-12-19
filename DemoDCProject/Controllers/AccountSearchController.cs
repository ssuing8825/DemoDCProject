using DemoDCProject.Models;
using DemoDCProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace DemoDCProject.Controllers
{
   
    public class AccountSearchController : ApiController
    {
        private DCService duckcreekAgent = new DCService();

        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary>
        /// Does a search by policy number for the accounts connnected to this. 
        /// </summary>
        /// <param name="policyNumber">The policy number.</param>
        /// <returns></returns>
        public string Get(int policyNumber)
        {

            //This is a search to 
            var reqdoc = ServiceCalls.SearchByPolicyReferenceRequest();
            reqdoc.Descendants("PolicyReference").First().SetValue(policyNumber);
            var dcresp = this.duckcreekAgent.CallDuckCreek(reqdoc.ToString());

            var result = XElement.Parse(dcresp);
            var accountNumber = result.Descendants("AccountId").First().Value;

            return accountNumber;
            
        }

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
