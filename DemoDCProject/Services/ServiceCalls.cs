using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DemoDCProject.Services
{
    public static class ServiceCalls
    {
        public static XElement SearchByPolicyReferenceRequest()
        {
            return XElement.Parse(@"<server>
                       <requests>
                          <Session.loginRq userName='admin' password='admin' />
                            <BillAccount.searchByPolicyReferenceRq>
                                <SearchRequestRecord>
                                <SearchCriteria>
                                <AccountSearchRecord>
                                <PolicyReference></PolicyReference>
                                </AccountSearchRecord>
                                </SearchCriteria>
                                    <SearchControl>
                                    <Paging>
                                        <ListStart>1</ListStart>
                                        <ListLength>100</ListLength>
                                    </Paging>
                                    <Filters>
                                    </Filters>
                                    </SearchControl>
                                </SearchRequestRecord>
                            </BillAccount.searchByPolicyReferenceRq>
                          <Session.closeRq />
                      </requests>
                    </server>");
        }

        public static XElement GetAccountSummaryRequest()
        {
            return XElement.Parse(@"<server>
                       <requests>
                          <Session.loginRq userName='admin' password='admin' />
                           <BillingObj.getAccountSummaryRq>
                                   <AccountId></AccountId>
                                   <TransactionDate></TransactionDate>
                                    </BillingObj.getAccountSummaryRq>
                          <Session.closeRq />
                      </requests>
                    </server>");
        }





    }
}