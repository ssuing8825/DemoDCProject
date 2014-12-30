using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DemoDCProject.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
   public class BillingAccountNotFoundException : NotFoundException
    {
        public BillingAccountNotFoundException() { }
        public BillingAccountNotFoundException(string message) : base(message) { }
        public BillingAccountNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected BillingAccountNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
