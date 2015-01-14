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
    public sealed class ServiceLocatorConfigurationInvalidException : DemoDCProjectTechnicalException
    {
        public ServiceLocatorConfigurationInvalidException() { }
        public ServiceLocatorConfigurationInvalidException(string message) : base(message) { }
        public ServiceLocatorConfigurationInvalidException(string message, Exception inner) : base(message, inner) { }
        private ServiceLocatorConfigurationInvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
