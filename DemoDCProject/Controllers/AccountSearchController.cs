using DemoDCProject.PublicDto;
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
        public async Task<BillingAccountDetail> Get(int policyNumber)
        {
            try
            {
                return await this.DomainFacade.RetrieveBillingAccountDetailByPolicyId(policyNumber);
            }
            catch (Exception ex)
            {
                throw ConstructHttpResponseException(string.Format("PolicyNumber: {0}", policyNumber), ex);
            }
        }
    }
}
