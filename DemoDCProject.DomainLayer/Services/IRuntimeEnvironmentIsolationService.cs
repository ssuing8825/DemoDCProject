using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Services
{
    public interface IRuntimeEnvironmentIsolationService
    {
        /// <summary>
        /// The Complete Website Url including http://, and the AppDomainAppVirtualPath
        /// </summary>
        string WebsiteUrl { get; }
        /// <summary>
        /// This property returns the "relative root path" for any HTML requirements
        /// you may have in the Domain Layer
        /// </summary>
        string AppDomainAppVirtualPath { get; }

        /// <summary>
        /// This property returns the physical "Root folder" of the application.
        /// You can use this property to get to any physical files on the local system
        /// </summary>
        string ServerRootFolder { get; }
    }
}
