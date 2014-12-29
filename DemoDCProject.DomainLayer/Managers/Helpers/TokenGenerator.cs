using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.Helpers
{
    internal sealed class TokenGenerator : TokenGeneratorBase
    {
        protected override string GenerateTokenCore()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
