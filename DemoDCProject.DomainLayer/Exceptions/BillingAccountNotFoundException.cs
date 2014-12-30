using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DemoDCProject.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    class BillingAccountNotFoundException : DemoDCProjectBusinessException
    {
        public BillingAccountNotFoundException() { }
        public BillingAccountNotFoundException(string message) : base(message) { }
        public BillingAccountNotFoundException(string message, Exception inner) : base(message, inner) { }
        private BillingAccountNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
