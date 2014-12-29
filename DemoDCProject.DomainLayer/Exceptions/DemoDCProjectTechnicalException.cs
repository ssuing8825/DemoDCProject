using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class DemoDCProjectTechnicalException : DemoDCProjectBaseException
    {
        public DemoDCProjectTechnicalException() { }
        public DemoDCProjectTechnicalException(string message) : base(message) { }
        public DemoDCProjectTechnicalException(string message, Exception inner) : base(message, inner) { }
        protected DemoDCProjectTechnicalException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
