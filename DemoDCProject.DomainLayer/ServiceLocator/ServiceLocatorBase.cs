using DemoDCProject.DomainLayer.DataLayer;
using DemoDCProject.DomainLayer.DataLayer.DataManagers;
using DemoDCProject.DomainLayer.Exceptions;
using DemoDCProject.DomainLayer.Gateways.Payment;
using DemoDCProject.DomainLayer.Managers;
using DemoDCProject.DomainLayer.Managers.Gateways.Billing;
using DemoDCProject.DomainLayer.Managers.Gateways.Payment;
using DemoDCProject.DomainLayer.Managers.Helpers;
using DemoDCProject.DomainLayer.Services;
using DemoDCProject.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.ServiceLocator
{
    [ExcludeFromCodeCoverage]
    internal abstract class ServiceLocatorBase
    {
        public IRuntimeEnvironmentIsolationService RuntimeEnvironmentIsolationService { get; set; }
        
        public ConfigurationProviderBase CreateConfigurationProvider()
        {
            return CreateConfigurationProviderCore();
        }

        public IRuntimeEnvironmentIsolationService CreateRuntimeEnvironmentIsolationService([CallerMemberName] string callerMemberName = "")
        {
            if (RuntimeEnvironmentIsolationService == null)
                throw new RuntimeEnvironmentIsolationProviderNotInitializedException("The RuntimeEnvironmentIsolationService property of the ServiceLocator has Not been initialized. The caller is: " + callerMemberName);
            return RuntimeEnvironmentIsolationService;
        }

        public TokenGeneratorBase CreateTokenProvider()
        {
            return CreateTokenGeneratorCore();
        }
        public TokenDataManagerBase CreateTokenDataManager()
        {
            return CreateTokenDataManagerCore();
        }

        protected abstract TokenDataManagerBase CreateTokenDataManagerCore();

        protected abstract TokenGeneratorBase CreateTokenGeneratorCore();
        protected abstract ConfigurationProviderBase CreateConfigurationProviderCore();

        public PaymentGatewayBase CreatePaymentGateway()
        {
            return CreatePaymentGatewayCore();
        }

        protected abstract PaymentGatewayBase CreatePaymentGatewayCore();

        public DbConnection CreateDbConnection(string connectionStringName)
        {
            return CreateDbConnectionCore(connectionStringName);
        }

        protected abstract DbConnection CreateDbConnectionCore(string connectionStringName);

        public PaymentManager CreatePaymentManager()
        {
            return CreatePaymentManagerCore();
        }
        protected abstract PaymentManager CreatePaymentManagerCore();


        public BillingAccountManager CreateBillingAccountManager()
        {
            return CreateBillingAccountManagerCore();
        }
        protected abstract BillingAccountManager CreateBillingAccountManagerCore();



        public DataFacade CreateDataFacade()
        {
            return CreateDataFacadeCore();
        }
        protected abstract DataFacade CreateDataFacadeCore();

        public BillingGatewayBase CreateBillingGateway()
        {
            return CreateBillingGatewayCore();
        }
        protected abstract BillingGatewayBase CreateBillingGatewayCore();

    }
}
