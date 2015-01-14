using DemoDCProject.DomainLayer;
using DemoDCProject.DomainLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.Console
{
    class Program
    {
        private static DomainFacade facade;

        static void Main(string[] args)
        {
            facade = new DomainFacade(new Environment());
              
            try
            {
                var task =  facade.RetrieveBillingAccountDetailByPolicyId(5);
                var account = task.Result;
                System.Console.Write(account.AccountId);
            }
            catch (Exception ex)
            {
                System.Console.Write(string.Format("PolicyNumber: {0} {1}", 5, ex));
            }
        }
    }

    public class Environment :  IRuntimeEnvironmentIsolationService
    {
        public string WebsiteUrl
        {
            get { throw new NotImplementedException(); }
        }

        public string AppDomainAppVirtualPath
        {
            get { throw new NotImplementedException(); }
        }

        public string ServerRootFolder
        {
            get { throw new NotImplementedException(); }
        }
    }
}
