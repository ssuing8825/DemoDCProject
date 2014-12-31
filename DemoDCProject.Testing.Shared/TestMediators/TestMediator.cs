using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoDCProject.Testing.Shared.TestMediators
{
    public class TestMediator
    {
        //This is a place holder class. YOu would put functions in here that can be called deep in the domain layer so you 
        //can test that those methods are being called.
        public void Reset()
        {
            StoreCreditCardVerificationNumberCountOfCreditCardsSent = 0;
        }
        public int StoreCreditCardVerificationNumberCountOfCreditCardsSent { get; set; }
    }
}
