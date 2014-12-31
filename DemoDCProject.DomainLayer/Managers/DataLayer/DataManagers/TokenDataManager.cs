using DemoDCProject.DomainLayer.DataLayer.DataManagers.CommandFactories;
using DemoDCProject.DomainLayer.Models.Domain;
using DemoDCProject.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.DataLayer.DataManagers
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
    }
}
