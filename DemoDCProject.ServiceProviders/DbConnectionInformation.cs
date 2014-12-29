using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.ServiceProviders
{
    /// <summary>
    /// This class hold ADO.NET Database connection specific information
    /// </summary>
    internal sealed class DbConnectionInformation
    {
        private readonly string providerInvariantName;
        public string ProviderInvariantName { get { return providerInvariantName; } }

        private readonly string connectionString;
        public string ConnectionString { get { return connectionString; } }

        public DbConnectionInformation(string connectionString, string providerInvariantName)
        {
            this.connectionString = connectionString;
            this.providerInvariantName = providerInvariantName;
        }
    }
}
