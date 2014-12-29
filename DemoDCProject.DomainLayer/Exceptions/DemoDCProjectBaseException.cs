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
    public class DemoDCProjectBaseException : Exception
    {
        public DemoDCProjectBaseException() { }
        public DemoDCProjectBaseException(string message) : base(message) { }
        public DemoDCProjectBaseException(string message, Exception inner) : base(message, inner) { }
        protected DemoDCProjectBaseException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
