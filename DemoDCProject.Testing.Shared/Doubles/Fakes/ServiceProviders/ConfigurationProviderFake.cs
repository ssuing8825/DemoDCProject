using DemoDCProject.ServiceProviders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.Testing.Shared.Doubles.Fakes.ServiceProviders
{
     [ExcludeFromCodeCoverage]
    internal sealed class ConfigurationProviderFake : ConfigurationProviderBase
    {
        private ConcurrentDictionary<string, string> configurationKeyValues = new ConcurrentDictionary<string, string>();
        private ConcurrentDictionary<string, DbConnectionInformation> dbConnectionInformationDictionary = new ConcurrentDictionary<string, DbConnectionInformation>();

        public void SetConfigurationSettingKeyValue(string key, string value)
        {
            string valueInContainer = null;
            if (configurationKeyValues.TryGetValue(key, out valueInContainer))
            {
                configurationKeyValues.TryUpdate(key, value, valueInContainer);
            }
            else
                configurationKeyValues.TryAdd(key, value);
        }

        public void SetDemoDCDbConnectionInformation(string connectionStringName, string providerInvariantName, string connectionString)
        {
            dbConnectionInformationDictionary.AddOrUpdate(connectionStringName, new DbConnectionInformation(connectionString, providerInvariantName), (connName, connectionInformation) => new DbConnectionInformation(connectionString, providerInvariantName));
        }

        protected override string GetConfigurationSettingValueThrowIfNotFound(string configurationSettingKey)
        {
            var valueInContainer = GetConfigurationSettingValue(configurationSettingKey);
            if (valueInContainer != null)
            {
                return valueInContainer;
            }
            else
                throw new ConfigurationErrorsException("The ConfigurationSettingKey: " + configurationSettingKey + " has not been initialized in ConfigurationProviderStub");
        }

        protected override string GetConfigurationSettingValue(string configurationSettingKey)
        {
            string valueInContainer = null;
            configurationKeyValues.TryGetValue(configurationSettingKey, out valueInContainer);
            return valueInContainer;
        }

        protected override DbConnectionInformation GetDbConnectionInformationCore(string connectionStringName)
        {
            DbConnectionInformation dbConnectionInformation;
            if (!dbConnectionInformationDictionary.TryGetValue(connectionStringName, out dbConnectionInformation))
                throw new ConfigurationErrorsException("No DbConnectionInformation with the name/identifier: " + connectionStringName + " was found in the DbConnectionInformationDictionary in the class ConfigurationProviderStub. Please initialize this value using the SetDbConnectionInformation method prior to calling GetDbConnectionInformation() method");

            if (string.IsNullOrEmpty(dbConnectionInformation.ConnectionString))
                throw new ConfigurationErrorsException("The ConnectionString property of the ConnectionString setting with the name: " + connectionStringName + " was found missing or empty.");

            if (string.IsNullOrEmpty(dbConnectionInformation.ProviderInvariantName))
                throw new ConfigurationErrorsException("The ProviderInvariantName property of the DbConnectionInformation associated with the name: " + connectionStringName + " was found missing or empty.");

            return new DbConnectionInformation(dbConnectionInformation.ConnectionString, dbConnectionInformation.ProviderInvariantName);
        }
    }
}
