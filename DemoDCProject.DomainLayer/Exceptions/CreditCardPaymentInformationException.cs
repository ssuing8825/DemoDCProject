using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class CreditCardPaymentInformationException : DemoDCProjectBusinessException
    {
        public CreditCardPaymentInformationException() { }
        public CreditCardPaymentInformationException(string message) : base(message) { }
        public CreditCardPaymentInformationException(string message, Exception inner) : base(message, inner) { }
        private CreditCardPaymentInformationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
     }
}
