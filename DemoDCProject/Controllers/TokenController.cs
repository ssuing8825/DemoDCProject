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
    public class TokenController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public CreditCard Get(int id)
        {
            return new CreditCard { CreditCardNumber = "************0912", Id = id, Token = Guid.NewGuid().ToString(), ExpDate = "0912" };
        }

        // POST api/values
        public CreditCard Post([FromBody]CreditCard value)
        {
            value.Id = 123;
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
