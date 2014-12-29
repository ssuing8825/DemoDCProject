using DemoDCProject.DomainLayer;
using DemoDCProject.DomainLayer.ServiceLocator;
using DemoDCProject.IntegrationTests.DemoDCProject.DomainLayer.TestHelpers;
using DemoDCProject.Testing.Shared.Doubles.Fakes.Services;
using DemoDCProject.Testing.Shared.TestMediators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.IntegrationTests
{
    [TestClass]
    public class EndToEndIntegrationTestsBase
    {
        internal static DomainFacade domainFacadeUnderTest;
        internal static TestMediator testMediator;

        protected static void Initialize(TestContext testContext)
        {
            testMediator = new TestMediator();
            var serviceLocator = ServiceLocatorConfigurator.ConfigureForEndToEndIntegrationTests(testMediator);

            var deploymentDirectory = testContext.DeploymentDirectory;
            //emailTemplatesFolder = deploymentDirectory + serviceLocator.CreateConfigurationProvider().EmailTemplateContainer;
            //Directory.CreateDirectory(emailTemplatesFolder);

            domainFacadeUnderTest = GetDomainFacadeUnderTest(serviceLocator, testContext);
        }

        private static DomainFacade GetDomainFacadeUnderTest(ServiceLocatorBase serviceLocator, TestContext testContext)
        {
            var deploymentDirectory = testContext.DeploymentDirectory;

            var domainFacadeUnderTest = new DomainFacade(serviceLocator,
                            new RuntimeEnvironmentIsolationServiceFake
                            {
                                AppDomainAppVirtualPath = "/",
                                ServerRootFolder = deploymentDirectory,
                                WebsiteUrl = "http://www.DemoDCProject.com/",
                            });

            return domainFacadeUnderTest;
        }

    }
}
