﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class DemoDCProjectBusinessException : DemoDCProjectBaseException
    {
        public DemoDCProjectBusinessException() { }
        public DemoDCProjectBusinessException(string message) : base(message) { }
        public DemoDCProjectBusinessException(string message, Exception inner) : base(message, inner) { }
        protected DemoDCProjectBusinessException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
