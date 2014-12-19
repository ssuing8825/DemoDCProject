using DemoDCProject.Models;
using DemoDCProject.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;

namespace DemoDCProject.Controllers
{

    public class BillingAccountController : ApiController
    {
        private DCService duckcreekAgent = new DCService();

        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary>
        /// Retrieves a billing account by accountId
        /// </summary>
        /// <param name="AccountId">The account number.</param>
        /// <returns></returns>
        public HttpResponseMessage Get(int AccountId)
        {

            //This is a search to 
            var reqdoc = ServiceCalls.GetAccountSummaryRequest();
            reqdoc.Descendants("AccountId").First().SetValue(AccountId);
            reqdoc.Descendants("TransactionDate").First().SetValue(DateTime.Now.ToShortDateString());
            var dcresp = this.duckcreekAgent.CallDuckCreek(reqdoc.ToString());

            var result = XElement.Parse(dcresp);

            dynamic j = new JObject();
            j.AccountId = result.Descendants("AccountId").First().Value;
            j.AccountReference = result.Descendants("AccountReference").First().Value;
            j.PastDueAmount = result.Descendants("PastDueAmount").First().Value;
            j.AccountStatus = result.Descendants("AccountStatus").First().Value;


            var response = new HttpResponseMessage()
            {
                Content = new StringContent(((JObject)j).ToString(), Encoding.UTF8, "application/json")
            };
            return response;

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
