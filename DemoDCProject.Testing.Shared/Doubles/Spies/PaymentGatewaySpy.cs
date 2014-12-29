using DemoDCProject.DomainLayer.Managers.Gateways.Payment;
using DemoDCProject.Testing.Shared.TestMediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.Testing.Shared.Doubles.Spies
{
    internal sealed class PaymentGatewaySpy : PaymentGatewayBase
    {
        private readonly TestMediator testMediator;

        public PaymentGatewaySpy(TestMediator testMediator)
        {
            this.testMediator = testMediator;

        }
        protected override string StoreCreditCardAtTokenProvidersCore(string creditCard, string expirationDate)
        {
            this.testMediator.MakePaymentVerificationNumberCountOfPaymentsSent++;
            return "";
        }
    }
}
