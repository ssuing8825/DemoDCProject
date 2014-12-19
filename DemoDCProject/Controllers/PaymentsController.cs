using DemoDCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoDCProject.Controllers
{
    [Authorize]
    public class PaymentsController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public PaymentAccounts Get(int id)
        {
            var p = new PaymentAccounts { BankAccounts = new List<CheckInfo>(), CreditCards = new List<CreditCard>() };

            p.CreditCards.Add(new CreditCard { CreditCardNumber = "************0912", Id = 2, Token = Guid.NewGuid().ToString(), ExpDate = "0912" });
            p.BankAccounts.Add(new CheckInfo { RoutingNumber = "123123123", Id = 2, AccountNumber = "123123123" });

            return p;
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
