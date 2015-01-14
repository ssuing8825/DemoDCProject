using DemoDCProject.DomainLayer.Managers.InternalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.DataLayer.DataManagers
{
    internal abstract class TokenDataManagerBase : DataManagerBase
    {
        public int CreateToken(Token token)
        {
            return CreateTokenCore(token);
        }
        public void DeleteTokenWithTokenNumber(string tokenNumber)
        {
            DeleteTokenWithTokenNumberCore(tokenNumber);
        }

        protected abstract void DeleteTokenWithTokenNumberCore(string tokenNumber);


        protected abstract int CreateTokenCore(Token token);

    }
}
