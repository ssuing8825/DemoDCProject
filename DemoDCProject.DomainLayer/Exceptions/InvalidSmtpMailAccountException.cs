using DemoDCProject.DomainLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DemoDCProject.DomainLayer.Gateways.Payment
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class InvalidTokenInfomationException : DemoDCProjectBaseException
    {
        public InvalidTokenInfomationException() { }
        public InvalidTokenInfomationException(string message) : base(message) { }
        public InvalidTokenInfomationException(string message, Exception inner) : base(message, inner) { }
        protected InvalidTokenInfomationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
