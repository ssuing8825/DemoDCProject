using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoDCProject.DomainLayer.Managers.Helpers
{
    internal abstract class TokenGeneratorBase
    {
        public string GenerateToken()
        {
            return GenerateTokenCore();
        }
        protected abstract string GenerateTokenCore();
    }
}
