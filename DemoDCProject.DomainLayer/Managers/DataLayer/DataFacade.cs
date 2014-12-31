using DemoDCProject.DomainLayer.DataLayer.DataManagers;
using DemoDCProject.DomainLayer.Models.Domain;
using DemoDCProject.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.DataLayer
{
    internal sealed class DataFacade
    {
        private readonly ServiceLocatorBase serviceLocator;

        private TokenDataManagerBase tokenDataManager { get; set; }
        private TokenDataManagerBase TokenDataManager { get { return tokenDataManager ?? (tokenDataManager = serviceLocator.CreateTokenDataManager()); } }

        public DataFacade(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public int CreateToken(Token token)
        {
            return TokenDataManager.CreateToken( token);
        }
    }
}
