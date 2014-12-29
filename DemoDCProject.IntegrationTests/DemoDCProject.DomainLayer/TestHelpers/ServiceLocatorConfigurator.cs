using DemoDCProject.DomainLayer.DataLayer.DataManagers;
using DemoDCProject.DomainLayer.Managers.Helpers;
using DemoDCProject.DomainLayer.ServiceLocator;
using DemoDCProject.ServiceProviders;
using DemoDCProject.Testing.Shared.Doubles.Fakes;
using DemoDCProject.Testing.Shared.Doubles.Spies;
using DemoDCProject.Testing.Shared.ServiceLocator;
using DemoDCProject.Testing.Shared.TestMediators;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.IntegrationTests.DemoDCProject.DomainLayer.TestHelpers
{
    internal static class ServiceLocatorConfigurator
    {
        private const string CONNECTION_STRING_NAME = "demodcprojectDb";

        public static ServiceLocatorBase ConfigureForEndToEndIntegrationTests(TestMediator testMediator)
        {
            // Using ServiceLocatorForUnitTesting because we'd like to stub out the RuntimeEnvironmentIsolationService
            // Since this is an End-To-End Integration test we should strive to use all other classes as Actual production classes
            var serviceLocator = new ServiceLocatorUnitTesting();
            serviceLocator.ConfigurationProviderFactory = () => new ConfigurationProviderLocal();

            serviceLocator.PaymentGatewayFactory = () => new PaymentGatewaySpy(testMediator);
            serviceLocator.TokenGeneratorFactory = () => new TokenGenerator();
            serviceLocator.TokenDataManagerFactory = () => new TokenDataManager(serviceLocator);
            serviceLocator.BillingGatewayFactory = () => new BillingGatewayFake(testMediator);  
            
            var demoDCProjectDbConnectionInformation = serviceLocator.CreateConfigurationProvider().GetDbConnectionInformation(CONNECTION_STRING_NAME);

            serviceLocator.DbConnectionFactory = () =>
            {
                var dbProviderFactory = DbProviderFactories.GetFactory(demoDCProjectDbConnectionInformation.ProviderInvariantName);
                var dbConn = dbProviderFactory.CreateConnection();
                dbConn.ConnectionString = demoDCProjectDbConnectionInformation.ConnectionString;
                return dbConn;

            };
            return serviceLocator;


        }
    }
}
