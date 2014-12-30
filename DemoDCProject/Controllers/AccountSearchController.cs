using DemoDCProject.DomainLayer.Models.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;

namespace DemoDCProject.Controllers
{
    public class AccountSearchController : ApiControllerBase
    {
        public async Task<BillingAccountSummary> Get(int policyNumber)
        {
            try
            {
                return await this.DomainFacade.RetrieveBillingAccountByPolicyId(policyNumber);
            }
            catch (Exception ex)
            {
                throw ConstructHttpResponseException(string.Format("PolicyNumber: {0}", policyNumber), ex);
            }
        }
    }
}
