using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.ServiceProviders
{
    /// <summary>
    /// This class's imlpementation uses/depends upon the System.Configuration
    /// infrastructure in .Net. Namely the web.config/app.config files
    /// </summary>
    internal sealed class ConfigurationProviderLocal : ConfigurationProviderBase
    {
        protected override string GetConfigurationSettingValueThrowIfNotFound(string configurationSettingKey)
        {
            var configurationSettingValue = GetConfigurationSettingValue(configurationSettingKey);
            if (String.IsNullOrEmpty(configurationSettingValue))
                throw new ConfigurationErrorsException("The configuration file (app.config or web.config) does not contain an appSetting element with a key attribute value of: \"" + configurationSettingKey + "\"");
            return configurationSettingValue;
        }

        protected override string GetConfigurationSettingValue(string configurationSettingKey)
        {
            return ConfigurationManager.AppSettings[configurationSettingKey];
        }

        protected override DbConnectionInformation GetDbConnectionInformationCore(string connectionName)
        {
            var connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionName];
            if (connectionStringSetting == null)
                throw new ConfigurationErrorsException("No ConnectionString setting with the name: \"" + connectionName + "\" was found in the connectionStrings section of the web.config or app.config file.");

            if (string.IsNullOrEmpty(connectionStringSetting.ConnectionString))
                throw new ConfigurationErrorsException("The connectionString attribute of the ConnectionString setting with the name: \"" + connectionName + "\" was found missing or empty.");

            if (string.IsNullOrEmpty(connectionStringSetting.ProviderName))
                throw new ConfigurationErrorsException("The providerInvariantName attribute of the ConnectionString setting with the name: \"" + connectionName + "\" was found missing or empty.");

            return new DbConnectionInformation(connectionStringSetting.ConnectionString, connectionStringSetting.ProviderName);
        }

    }
}
