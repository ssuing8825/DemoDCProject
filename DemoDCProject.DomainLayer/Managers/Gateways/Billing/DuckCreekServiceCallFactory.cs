using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Gateways.Billing
{
    internal static class DuckCreekServiceCallFactory
    {
        private const string GET_ACCOUNT_SUMMARY_REQUEST = @"<server>
                       <requests>
                          <Session.loginRq userName='admin' password='admin' />
                           <BillingObj.getAccountSummaryRq>
                                   <AccountId>{0}</AccountId>
                                   <TransactionDate>{1}</TransactionDate>
                                    </BillingObj.getAccountSummaryRq>
                          <Session.closeRq />
                      </requests>
                    </server>";


        //        public static XElement SearchByPolicyReferenceRequest()
        //        {
        //            return string.format(@"<server>
        //                       <requests>
        //                          <Session.loginRq userName='admin' password='admin' />
        //                            <BillAccount.searchByPolicyReferenceRq>
        //                                <SearchRequestRecord>
        //                                <SearchCriteria>
        //                                <AccountSearchRecord>
        //                                <PolicyReference></PolicyReference>
        //                                </AccountSearchRecord>
        //                                </SearchCriteria>
        //                                    <SearchControl>
        //                                    <Paging>
        //                                        <ListStart>1</ListStart>
        //                                        <ListLength>100</ListLength>
        //                                    </Paging>
        //                                    <Filters>
        //                                    </Filters>
        //                                    </SearchControl>
        //                                </SearchRequestRecord>
        //                            </BillAccount.searchByPolicyReferenceRq>
        //                          <Session.closeRq />
        //                      </requests>
        //                    </server>");
        //        }

        public static string GetAccountSummaryRequest(int accountId, DateTime transactionDate)
        {
            //if you need to do massive manipulation you can use an XElement.
            return string.Format(GET_ACCOUNT_SUMMARY_REQUEST, accountId.ToString(), transactionDate.ToShortDateString());
        }
    }
}
