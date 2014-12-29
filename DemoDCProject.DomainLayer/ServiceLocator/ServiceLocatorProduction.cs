using DemoDCProject.DomainLayer.DataLayer;
using DemoDCProject.DomainLayer.DataLayer.DataManagers;
using DemoDCProject.DomainLayer.Managers;
using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.DomainLayer.Managers.Gateways.Payment;
using DemoDCProject.DomainLayer.Managers.Helpers;
using DemoDCProject.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.ServiceLocator
{
    [ExcludeFromCodeCoverage]
    internal sealed class ServiceLocatorProduction : ServiceLocatorBase
    {
        private ConfigurationProviderBase configurationProvider;
        protected override ConfigurationProviderBase CreateConfigurationProviderCore()
        {
            if (configurationProvider == null)
                configurationProvider = new ConfigurationProviderLocal();
            return configurationProvider;
        }

        protected override TokenGeneratorBase CreateTokenGeneratorCore()
        {
            return new TokenGenerator();
        }

        protected override PaymentGatewayBase CreatePaymentGatewayCore()
        {
            return new PaymentTechPaymentGateway(this);
        }

        protected override PaymentManager CreatePaymentManagerCore()
        {
            return new PaymentManager(this);
        }
        protected override TokenDataManagerBase CreateTokenDataManagerCore()
        {
            return new TokenDataManager(this);
        }
        private DbConnection dbConnection;
        protected override DbConnection CreateDbConnectionCore(string connectionStringName)
        {
            if (dbConnection == null)
            {
                var connectionInformation = CreateConfigurationProvider().GetDbConnectionInformation(connectionStringName);
                dbConnection = DbProviderFactories.GetFactory(connectionInformation.ProviderInvariantName).CreateConnection();
                dbConnection.ConnectionString = connectionInformation.ConnectionString;
            }

            return dbConnection;
        }

        private DataFacade dataFacade;
        protected override DataFacade CreateDataFacadeCore()
        {
            if (dataFacade == null)
                dataFacade = new DataFacade(this);
            return dataFacade;
        }

        protected override BillingGatewayBase CreateBillingGatewayCore()
        {
            return new DuckCreekBillingGateway(this);
        }
    }
}
