using DemoDCProject.DomainLayer.Managers.DataLayer.DataManagers.CommandFactories;
using DemoDCProject.DomainLayer.Managers.InternalDto;
using DemoDCProject.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Managers.DataLayer.DataManagers
{
    internal sealed class TokenDataManager : TokenDataManagerBase
    {
        private readonly DbConnection dbConnection;
        public TokenDataManager(ServiceLocatorBase serviceLocator)
        {
            dbConnection = GetDbConnectionDemoDCProject(serviceLocator);
        }

        protected override int CreateTokenCore(Token token)
        {
            return ExecuteNonQueryUsingTransactionAndReturnValue<Token, int>(dbConnection, CommandFactoryForTokenDataManager.CreateCommandForCreateToken, token);
        }

        protected override void DeleteTokenWithTokenNumberCore(string tokenNumber)
        {
            ExecuteNonQueryUsingTransaction<string>(dbConnection, CommandFactoryForTokenDataManager.CreateCommandForDeleteTokenWithTokenNumber, tokenNumber);

        }
    }
}
