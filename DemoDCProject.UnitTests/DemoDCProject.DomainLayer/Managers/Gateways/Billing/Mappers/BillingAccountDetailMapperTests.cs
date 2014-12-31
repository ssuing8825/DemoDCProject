using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoDCProject.DomainLayer.Managers.Gateways.Billing;

namespace DemoDCProject.UnitTests.DemoDCProject.DomainLayer.Managers.Gateways.Billing.Mappers
{
    [TestClass]
    public class BillingAccountDetailMapperTests
    {
   
                   private const string EXAMPLE_RESPONSE = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                <!-- EXAMPLE Server Version 6.0 -->
                                <server>
                                    <responses>
                                        <Session.loginRs status=""success"" sessionID=""1E842558:CC12428A:9303A439:6B227B36:7A35D91D:48E90C41"" expiredPassword=""0"" fullName=""Express Admin"" roleBasedSecurity=""1"" entityID=""1"" userID=""1"" partyID=""0"" consumerID=""0"" />
                                        <BillingObj.getAccountSummaryRs status=""success"">
                                            <Account 
                                                xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                <AccountId>10003</AccountId>
                                                <AccountReference>000005</AccountReference>
                                                <AccountStatus>Active</AccountStatus>
                                                <CollectionMethod>PA</CollectionMethod>
                                                <AccountType>Account</AccountType>
                                                <AccountTypeCode>ACT</AccountTypeCode>
                                                <AccountClass>DCD1</AccountClass>
                                                <TargetDueDays>20</TargetDueDays>
                                                <NSFCounter>0</NSFCounter>
                                                <DisbursementHold xsi:nil=""true"" />
                                                <CurrencyCulture>en-US</CurrencyCulture>
                                                <OutstandingBalance>35.5500</OutstandingBalance>
                                                <EFTPaymentDetails>
                                                    <AccountName />
                                                    <LastName />
                                                    <Activated>0</Activated>
                                                    <BankRoutingNumber />
                                                    <BankAccountNumber />
                                                    <AccountType />
                                                </EFTPaymentDetails>
                                                <HoldTypeCode>N</HoldTypeCode>
                                                <HoldType>No Hold</HoldType>
                                                <HoldReasonCode xsi:nil=""true"" />
                                                <HoldReason xsi:nil=""true"" />
                                                <HoldStartDate xsi:nil=""true"" />
                                                <HoldEndDate xsi:nil=""true"" />
                                                <HoldEventName xsi:nil=""true"" />
                                                <HoldEventId xsi:nil=""true"" />
                                                <ProcessingOrgUnit>DCD1</ProcessingOrgUnit>
                                                <ProcessingOrgUnitCode>9999</ProcessingOrgUnitCode>
                                                <InSuspenseAmount xsi:nil=""true"" />
                                                <CurrentDueAmount xsi:nil=""true"" />
                                                <PastDueAmount>35.5500</PastDueAmount>
                                                <PendingDisbursements>0.0000</PendingDisbursements>
                                                <AccountConfig>
                                                    <Disbursements id=""DF29E03C0293B4284A267B668E753AB7F"" DisbMthd=""CK"" HoldDisbInd=""1"" RefundToSource=""1"" AutomaticDisbursementAuthorizationLimit=""0"" />
                                                    <Scheduling id=""S9CB59DC0007B41449CDCBEFE7E5ACF2B"" BillPrdOffset=""20"" OCBAllow=""0"" Freq=""MONTHLY"" EFTDrawOffset=""7"" LateEnterStgy=""C"" EFTPreNote=""1"" DFPolMSId=""Billing_PolicyPlanSetup_DirectBase_1_0_0_0"" PlanCode=""DC_ACT_A1"" EIOffsetDays=""15"" BlackOutDatesCalendar=""BusinessCalendar"" />
                                                    <Suspense id=""S65EFEF1987BF49DEB81B1FED745B3B33"" AutoProcHoldCWA=""30"" AutoDisbMaxAmt=""99999999"" AutoDisbMinAmt=""4.99"" AutoProcHold=""5"" AutoProcIndicator=""1"" />
                                                    <Payment id=""P5F3E41E3725E419781524D4A72974F3A"" NSFChgAct=""A"" NSFChgAmt=""6"" RevAdjRsn=""CM"" XSAlloc=""S"" GrNetInd=""G"" DaysOffsetUpdatePendingDraws=""0"" LockboxMatchExactAmount=""0"" />
                                                    <Invoice id=""I5B6165423F714A02A31B43EA6254DFD4"" LineTypeRollup=""1"" AccountRollup=""1"" PolicyRollup=""1"" ReceivableTypeRollup=""1"" ReceivableSubTypeRollup=""0"" TransactionTypeRollup=""0"" CoverageRollup=""0"" UnitRollup=""0"" AggregationRollup=""0"" CommissionRollup=""0"" BillItemRollup=""0"" FormMS=""Carrier_Billing_InvoiceForm_1_0_0_0"" InvMthd=""PA"" EFTRepCt=""0"" EFTRepDays=""2"" EFTSvcChgAmt=""0"" EFTSvcChgAct=""N"" PASvcChgAmt=""0"" PASvcChgAct=""N"" PAInvThreshAmt=""5"" EFTInvThreshAmt=""0.01"" PrintJob=""InvoicePrint"" PASvcChgPct=""0"" EFTSvcChgPct=""0"" SvcChgMinAmt=""0"" SvcChgMaxAmt=""9999999"" ChgNotThresh=""0.01"" EFTFrmReq=""1"" UseProjectedServiceCharge=""1"" DebitChangeNoticeManuScriptId=""Carrier_Billing_Debit_Change_Notice_1_0_0_0"" DebitChangeNoticeGenerateField=""DebitChangeNoticePrivate.Generate"" IncludePCN=""0"" ElectronicInvoice=""0"" EISvcChgAmt=""0"" EISvcChgAct="""" EISvcChgPct=""0"" EInvThreshAmt=""0"" InvoiceTolerance=""0"">
                                                        <GenerateDetailedInvoice>1</GenerateDetailedInvoice>
                                                        <PaperInvoiceServiceChargeExclusions id=""PD684B86AA293409C8C974E75890691FF"" />
                                                        <EFTInvoiceServiceChargeExclusions id=""E22010A4AB4AE4420BE0C22B2C1BC3E7D"">
                                                            <EFTSCX id=""E1DFA74D02C3E4EBBA3C6E66FCC992F27"" name=""AccountCharges"">
                                                                <InvoiceLineType>*</InvoiceLineType>
                                                                <ReceivableSubType>*</ReceivableSubType>
                                                                <ReceivableType>CH</ReceivableType>
                                                                <TransactionType>*</TransactionType>
                                                            </EFTSCX>
                                                        </EFTInvoiceServiceChargeExclusions>
                                                        <ElectronicInvoiceServiceChargeExclusions id=""E1041B7B929C244BBAA1D4C8D9AF16148"" />
                                                    </Invoice>
                                                    <FollowUp id=""F09876B9DA8D041C0A99268A492466F86"" LateChgAct=""N"" LateChgDays=""3"" LateChgAmt=""10"" LateChgThresh=""10"" RemNtcAct=""N"" RemNtcDays=""0"" RemNtcThresh=""10"" />
                                                    <AllocationPriorities id=""A241C0BE0B2444DACB8E0035CB8E3D68B"">
                                                        <AP id=""A5867F64C534B4ED4B7B3B71C6083D5A7"" Pty=""20"" Rec=""COMM"" />
                                                        <AP id=""A1B375D42208345ED8C08AAAB69C78A53"" Pty=""20"" Rec=""DBRB"" />
                                                        <AP id=""AEE0D31AC0EF14A0193F76970521C0C11"" Pty=""20"" Rec=""L"" />
                                                        <AP id=""AB5F43B2708A04A2AB4250E97989C95FF"" Pty=""20"" Rec=""N"" />
                                                        <AP id=""AFABEFE307AF14AA78D90F79069F6879C"" Pty=""20"" Rec=""REIN"" />
                                                        <AP id=""AABE84B676E3C40C489796163C14ECA9E"" Pty=""20"" Rec=""RREV"" />
                                                        <AP id=""A7E739B130F3640BE81972CED3724E705"" Pty=""20"" Rec=""S"" />
                                                    </AllocationPriorities>
                                                </AccountConfig>
                                                <AccountExtendedData xsi:nil=""true"" />
                                                <AccountLockingTS>AAAAAAABX54=</AccountLockingTS>
                                                <PolicyTerms 
                                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" count=""1"">
                                                    <PolicyTerm>
                                                        <PolicyTermId>10003</PolicyTermId>
                                                        <PolicyTermEffectiveDate>2014-11-20</PolicyTermEffectiveDate>
                                                        <PolicyTermExpirationDate>2015-11-20</PolicyTermExpirationDate>
                                                        <PolicyReference>000005</PolicyReference>
                                                        <HoldTypeCode>N</HoldTypeCode>
                                                        <PolicyIssueSystemCode>DCT</PolicyIssueSystemCode>
                                                        <PolicyTermStatus>Pending Cancellation</PolicyTermStatus>
                                                        <PolicyLineOfBusiness>Line 1</PolicyLineOfBusiness>
                                                        <PastDueAmount>35.5500</PastDueAmount>
                                                        <OutstandingBalance>35.5500</OutstandingBalance>
                                                        <PolicyTermExtendedData>
                                                            <AllowPaymentAllocation>1</AllowPaymentAllocation>
                                                            <PIFEligibilityFlag>0</PIFEligibilityFlag>
                                                            <AuditData>
                                                                <Auditable>0</Auditable>
                                                            </AuditData>
                                                            <PolicyStatus>
                                                                <StatusCode>PC</StatusCode>
                                                                <EffectiveDate>2014-12-30</EffectiveDate>
                                                                <ReasonCode>NP</ReasonCode>
                                                                <RescindAmount>3.0685</RescindAmount>
                                                            </PolicyStatus>
                                                        </PolicyTermExtendedData>
                                                        <PASPolicyId>1003</PASPolicyId>
                                                    </PolicyTerm>
                                                </PolicyTerms>
                                                <AssociatedParties 
                                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                    <Party PartyId=""1"" Role=""Agent"" PartyInvolvementId=""10011"" PartyInvolvementLockingTS=""AAAAAAABIWM="" />
                                                    <Party PartyId=""20003"" Role=""Payee"" PartyInvolvementId=""10010"" PartyInvolvementLockingTS=""AAAAAAABIV4="" />
                                                    <Party PartyId=""20003"" Role=""Payor"" PartyInvolvementId=""10009"" PartyInvolvementLockingTS=""AAAAAAABIV0="" />
                                                </AssociatedParties>
                                                <Payments 
                                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                    <Payment>
                                                        <PaymentId>10002</PaymentId>
                                                        <PaymentAmount>1.2000</PaymentAmount>
                                                        <CurrencyCulture>en-US</CurrencyCulture>
                                                        <PaymentMethod>Check</PaymentMethod>
                                                        <PaymentEntryDate>2014-11-25</PaymentEntryDate>
                                                    </Payment>
                                                </Payments>
                                                <Invoices 
                                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                    <Invoice>
                                                        <InvoiceId>2</InvoiceId>
                                                        <InvoiceDate>2014-11-26</InvoiceDate>
                                                        <DueDate>2014-12-16</DueDate>
                                                        <AccountId>10003</AccountId>
                                                        <CurrentDueAmount>35.5500</CurrentDueAmount>
                                                        <PastDueAmount>0.0000</PastDueAmount>
                                                        <InvoiceTotalAmount>35.5500</InvoiceTotalAmount>
                                                        <CurrencyCulture>en-US</CurrencyCulture>
                                                        <AttachmentID>2</AttachmentID>
                                                        <Moniker>17\D46595524603478AB4DB8555DAA2D36B.pdf</Moniker>
                                                        <FileName>0000000001-Invoice-1.pdf</FileName>
                                                    </Invoice>
                                                </Invoices>
                                                <NextScheduledInvoice 
                                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                    <InvoiceDate>2014-12-31T00:00:00</InvoiceDate>
                                                    <Amount>0.0000</Amount>
                                                    <InvoiceDueDate>2015-01-20T00:00:00</InvoiceDueDate>
                                                </NextScheduledInvoice>
                                                <Parties 
                                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                    <PartyRecord 
                                                        xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                        <PartyRecordPartyId>1</PartyRecordPartyId>
                                                        <AgencyId>1</AgencyId>
                                                        <AgencyExtensions>
                                                            <misc id=""mE0ED005CE7DE4A5590EB76F268B635E3"">
                                                                <license id=""l9CF2F626A051497E9958E3BB398307B1"">
                                                                    <State>AL</State>
                                                                    <LicenseNumber>Add</LicenseNumber>
                                                                    <LicenseDate />
                                                                </license>
                                                                <EmployeeCount />
                                                                <license id=""l7D4240006BF144C88634A2F21D8DD48D"">
                                                                    <State>AL</State>
                                                                    <LicenseNumber>Add2</LicenseNumber>
                                                                    <LicenseDate />
                                                                </license>
                                                            </misc>
                                                        </AgencyExtensions>
                                                        <Party>
                                                            <PartyName>Internal Users</PartyName>
                                                            <PartyContactName />
                                                            <PartyFirstName xsi:nil=""true"" />
                                                            <PartyMiddleName xsi:nil=""true"" />
                                                            <PartyNamePrefix xsi:nil=""true"" />
                                                            <PartyNameSuffix xsi:nil=""true"" />
                                                            <PartyGender xsi:nil=""true"" />
                                                            <PartyBirthDate xsi:nil=""true"" />
                                                            <PartyCorrespondenceName>Internal Users</PartyCorrespondenceName>
                                                            <PartyTypeCode>AG</PartyTypeCode>
                                                        </Party>
                                                        <PartyReferences>
                                                            <PartyReference>
                                                                <Reference xsi:nil=""true"" />
                                                            </PartyReference>
                                                        </PartyReferences>
                                                        <PartyPhones>
                                                            <PartyPhone>
                                                                <PhoneNumber />
                                                                <PhoneExtension />
                                                                <PhoneCountryCode xsi:nil=""true"" />
                                                                <PhoneFormatCode>US1</PhoneFormatCode>
                                                            </PartyPhone>
                                                        </PartyPhones>
                                                        <Locations>
                                                            <Location>
                                                                <LocationAddressLine1 />
                                                                <LocationAddressLine2 />
                                                                <LocationCity />
                                                                <LocationStateCode />
                                                                <LocationPostalCode />
                                                            </Location>
                                                        </Locations>
                                                        <PartyEmails>
                                                            <PartyEmail>
                                                                <EmailAddress xsi:nil=""true"" />
                                                            </PartyEmail>
                                                        </PartyEmails>
                                                    </PartyRecord>
                                                    <PartyRecord 
                                                        xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                                        <PartyRecordPartyId>20003</PartyRecordPartyId>
                                                        <Party>
                                                            <PartyName>sdfgsd</PartyName>
                                                            <PartyFirstName xsi:nil=""true"" />
                                                            <PartyMiddleName xsi:nil=""true"" />
                                                            <PartyNamePrefix xsi:nil=""true"" />
                                                            <PartyNameSuffix xsi:nil=""true"" />
                                                            <PartyGender xsi:nil=""true"" />
                                                            <PartyBirthDate xsi:nil=""true"" />
                                                            <PartyCorrespondenceName>sdfgsd</PartyCorrespondenceName>
                                                            <PartyTypeCode>P</PartyTypeCode>
                                                        </Party>
                                                        <PartyPhones>
                                                            <PartyPhone>
                                                                <PhoneNumber>2342222344</PhoneNumber>
                                                                <PhoneExtension xsi:nil=""true"" />
                                                                <PhoneCountryCode>USA</PhoneCountryCode>
                                                                <PhoneFormatCode>US1</PhoneFormatCode>
                                                            </PartyPhone>
                                                        </PartyPhones>
                                                        <PartyEmails>
                                                            <PartyEmail>
                                                                <EmailAddress xsi:nil=""true"" />
                                                            </PartyEmail>
                                                        </PartyEmails>
                                                        <Locations>
                                                            <Location>
                                                                <LocationAddressLine1>dsfg</LocationAddressLine1>
                                                                <LocationAddressLine2 xsi:nil=""true"" />
                                                                <LocationCounty xsi:nil=""true"" />
                                                                <LocationCity>sdfg</LocationCity>
                                                                <LocationStateCode>AK</LocationStateCode>
                                                                <LocationPostalCode>23423</LocationPostalCode>
                                                                <LocationCountryCode xsi:nil=""true"" />
                                                            </Location>
                                                        </Locations>
                                                        <AuthorizedInterest>
                                                            <Name>Internal Users</Name>
                                                        </AuthorizedInterest>
                                                    </PartyRecord>
                                                </Parties>
                                                <ResponseInfo>
                                                    <ReturnCode>0</ReturnCode>
                                                    <NotificationResponse />
                                                </ResponseInfo>
                                            </Account>
                                        </BillingObj.getAccountSummaryRs>
                                        <Session.closeRs status=""success""/>
                                    </responses>
                                </server>";

        [TestMethod]
        [TestCategory("Class Test")]
        public void BillingAccountSummaryMappingTest()
        {
            var result = BillingAccountDetailMapper.FromXml(EXAMPLE_RESPONSE);

            Assert.AreEqual(10003, result.AccountId);
            Assert.AreEqual(00005, result.AccountReference);
            Assert.AreEqual(35.5500m, result.PastDueAmount);
            Assert.AreEqual("Active", result.AccountStatus);
        }
    }
}
