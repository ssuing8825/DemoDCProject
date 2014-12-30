using DemoDCProject.DomainLayer.Managers;
using DemoDCProject.DomainLayer.ServiceLocator;
using DemoDCProject.DomainLayer.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer
{

    public sealed partial class DomainFacade
    {
        private readonly ServiceLocatorBase serviceLocator;

        private PaymentManager paymentManager;
        private PaymentManager PaymentManager { get { return paymentManager ?? (paymentManager = serviceLocator.CreatePaymentManager()); } }

        private BillingAccountManager billingAccountManager;
        private BillingAccountManager BillingAccountManager { get { return billingAccountManager ?? (billingAccountManager = serviceLocator.CreateBillingAccountManager()); } }
 

        [ExcludeFromCodeCoverage]
        public DomainFacade(IRuntimeEnvironmentIsolationService runtimeEnvironmentIsolationService)
            : this(ServiceLocatorResolver.Resolve(), runtimeEnvironmentIsolationService)
        {
        }

        internal DomainFacade(ServiceLocatorBase serviceLocator, IRuntimeEnvironmentIsolationService runtimeEnvironmentIsolationService)
        {
            this.serviceLocator = serviceLocator;
            this.serviceLocator.RuntimeEnvironmentIsolationService = runtimeEnvironmentIsolationService;
        }

    }
}
