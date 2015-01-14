using DemoDCProject.DomainLayer.Exceptions;
using DemoDCProject.DomainLayer.Gateways.Payment;
using DemoDCProject.DomainLayer.Managers;
using DemoDCProject.DomainLayer.Managers.DataLayer;
using DemoDCProject.DomainLayer.Managers.DataLayer.DataManagers;
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
             
        public PaymentGatewayBase CreatePaymentGateway()
        {
            return CreatePaymentGatewayCore();
        }
             
        public DbConnection CreateDbConnection(string connectionStringName)
        {
            return CreateDbConnectionCore(connectionStringName);
        }
              
        public PaymentManager CreatePaymentManager()
        {
            return CreatePaymentManagerCore();
        }
             
        public BillingAccountManager CreateBillingAccountManager()
        {
            return CreateBillingAccountManagerCore();
        }
               
        public DataFacade CreateDataFacade()
        {
            return CreateDataFacadeCore();
        }

        public BillingGatewayBase CreateBillingGateway()
        {
            return CreateBillingGatewayCore();
        }

        public LogProviderBase CreateLogProvider()
        {
            return CreateLogProviderCore();

        }
        protected abstract DataFacade CreateDataFacadeCore();
        protected abstract BillingGatewayBase CreateBillingGatewayCore();
        protected abstract PaymentGatewayBase CreatePaymentGatewayCore();
        protected abstract DbConnection CreateDbConnectionCore(string connectionStringName);
        protected abstract PaymentManager CreatePaymentManagerCore();
        protected abstract BillingAccountManager CreateBillingAccountManagerCore();
        protected abstract TokenDataManagerBase CreateTokenDataManagerCore();
        protected abstract TokenGeneratorBase CreateTokenGeneratorCore();
        protected abstract ConfigurationProviderBase CreateConfigurationProviderCore();
        protected abstract LogProviderBase CreateLogProviderCore();
    }
}
