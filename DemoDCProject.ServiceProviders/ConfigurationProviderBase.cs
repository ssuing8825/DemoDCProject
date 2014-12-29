using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.ServiceProviders
{
    internal abstract class ConfigurationProviderBase
    {
        /// <summary>
        /// This method returns an instance of <see cref="ConnectionInformation"/> that is extracted from either
        /// the connectionStrings section of a config file or some other location.
        /// Descendants should implement this method in such as way that specialized exceptions are thrown
        /// indicating exactly what settings are missing and from where (what section of a config file or other location)
        /// </summary>
        /// <param name="connectionName">The value of the \"name\" attribute of a connectionString item in a config file or an identifier if another location is used</param>
        /// <returns>An instance of a <see cref="ConnectionInformation"/> class that contains the ProviderinvariantName and ConnectionString properties</returns>
        public DbConnectionInformation GetDbConnectionInformation(string connectionName)
        {
            return GetDbConnectionInformationCore(connectionName);
        }

        /// <summary>
        /// Specialized Properties can call this method in Descendant's when configuration settings
        /// are NOT optional. Decendant's can implement this method in such as way that their implementation
        /// throws an exception with the proper exception message indicating the missing configuration setting
        /// </summary>
        /// <param name="configurationSettingKey">The Configuration Setting Key</param>
        /// <returns>The Configuration Setting Value</returns>
        protected abstract string GetConfigurationSettingValueThrowIfNotFound(string configurationSettingKey);

        /// <summary>
        /// Specialized Properties can call this method in Descendant's when configuration settings are optional
        /// or have a default value when not present/specified
        /// </summary>
        /// <param name="configurationSettingKey">The Configuration Setting Key</param>
        /// <returns>The Configuration Setting Value</returns>
        protected abstract string GetConfigurationSettingValue(string configurationSettingKey);

        /// <summary>
        /// This method returns an instance of <see cref="ConnectionInformation"/> that is extracted from either
        /// the connectionStrings section of a config file or some other location.
        /// Descendants should implement this method in such as way that specialized exceptions are thrown
        /// indicating exactly what settings are missing and from where (what section of a config file or other location)
        /// </summary>
        /// <param name="connectionName">The value of the \"name\" attribute of a connectionString item in a config file or an identifier if another location is used</param>
        /// <returns>An instance of a <see cref="ConnectionInformation"/> class that contains the ProviderinvariantName and ConnectionString properties</returns>
        protected abstract DbConnectionInformation GetDbConnectionInformationCore(string connectionName);
    }
}
