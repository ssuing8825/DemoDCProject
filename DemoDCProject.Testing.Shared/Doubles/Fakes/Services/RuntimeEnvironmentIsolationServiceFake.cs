using DemoDCProject.DomainLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.Testing.Shared.Doubles.Fakes.Services
{
    class RuntimeEnvironmentIsolationServiceFake : IRuntimeEnvironmentIsolationService
    {
        public string AppDomainAppVirtualPath { get; set; }

        public string ServerRootFolder { get; set; }

        public string WebsiteUrl { get; set; }
    }
}
