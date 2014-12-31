using DemoDCProject.DomainLayer.Exceptions;
using DemoDCProject.DomainLayer.Managers;
using DemoDCProject.DomainLayer.Managers.DataLayer;
using DemoDCProject.DomainLayer.Managers.DataLayer.DataManagers;
using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.DomainLayer.Managers.Gateways.Payment;
using DemoDCProject.DomainLayer.Managers.Helpers;
using DemoDCProject.DomainLayer.ServiceLocator;
using DemoDCProject.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.Testing.Shared.ServiceLocator
{
    internal class ServiceLocatorUnitTesting : ServiceLocatorBase
    {
        public Func<ConfigurationProviderBase> ConfigurationProviderFactory = null;
        public Func<DbConnection> DbConnectionFactory = null;
        public Func<TokenGeneratorBase> TokenGeneratorFactory = null;
        public Func<PaymentGatewayBase> PaymentGatewayFactory = null;
        public Func<TokenDataManagerBase> TokenDataManagerFactory = null;
        public Func<BillingGatewayBase> BillingGatewayFactory = null;

        private static Exception CreateFactoryNotInitializedException(string factoryName, string baseClassName)
        {
            return new ServiceLocatorConfigurationInvalidException(string.Format("For Unit Testing you MUST initialize the public static member: {0} such that it returns an instance of a descendant of: {1}", factoryName, baseClassName));
        }

        protected override TokenGeneratorBase CreateTokenGeneratorCore()
        {
            if (TokenGeneratorFactory == null)
                throw CreateFactoryNotInitializedException("TokenGeneratorFactory", "TokenGeneratorBase");
            return TokenGeneratorFactory();
        }

        protected override PaymentGatewayBase CreatePaymentGatewayCore()
        {
            if (PaymentGatewayFactory == null)
                throw CreateFactoryNotInitializedException("PaymentGatewayFactory", "PaymentGatewayBase");
            return PaymentGatewayFactory();
        }


        private ConfigurationProviderBase configurationProvider;
        protected override ConfigurationProviderBase CreateConfigurationProviderCore()
        {
            if (configurationProvider == null)
            {
                if (ConfigurationProviderFactory == null)
                    throw CreateFactoryNotInitializedException("ConfigurationProviderFactory", "ConfigurationProviderBase");

                configurationProvider = ConfigurationProviderFactory();
            }

            return configurationProvider;
        }

        protected override PaymentManager CreatePaymentManagerCore()
        {
            return new PaymentManager(this);
        }

        protected override BillingGatewayBase CreateBillingGatewayCore()
        {
            if (BillingGatewayFactory == null)
                throw CreateFactoryNotInitializedException("BillingGatewayFactory", "BillingGatewayBase");
            return BillingGatewayFactory();
        }

        private DbConnection dbConnection;
        protected override DbConnection CreateDbConnectionCore(string connectionStringName)
        {
            if (dbConnection == null)
            {
                if (DbConnectionFactory == null)
                    throw CreateFactoryNotInitializedException("DbConnectionFactory", "DbConnection");

                dbConnection = DbConnectionFactory();
            }

            return dbConnection;
        }


        protected override TokenDataManagerBase CreateTokenDataManagerCore()
        {
            if (TokenDataManagerFactory == null)
                throw CreateFactoryNotInitializedException("TokenDataManagerFactory", "TokenDataManagerBase");
            return TokenDataManagerFactory();
        }

        protected override DataFacade CreateDataFacadeCore()
        {
            return new DataFacade(this);
        }

        protected override BillingAccountManager CreateBillingAccountManagerCore()
        {
            return new BillingAccountManager(this);
        }
    }
}
