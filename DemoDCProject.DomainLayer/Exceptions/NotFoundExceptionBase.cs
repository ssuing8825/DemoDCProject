using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DemoDCProject.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
   public class NotFoundException : DemoDCProjectBusinessException
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }
        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
