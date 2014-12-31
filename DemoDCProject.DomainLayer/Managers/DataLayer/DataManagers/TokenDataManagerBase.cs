using DemoDCProject.DomainLayer.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.DataLayer.DataManagers
{
    internal abstract class TokenDataManagerBase : DataManagerBase
    {
        public int CreateToken(Token token)
        {
            return CreateTokenCore(token);
        }

        protected abstract int CreateTokenCore(Token token);
    }
}
