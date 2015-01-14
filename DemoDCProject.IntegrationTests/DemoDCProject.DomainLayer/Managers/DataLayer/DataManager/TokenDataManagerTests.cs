using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoDCProject.Testing.Shared.Doubles.Fakes.ServiceProviders;
using System.Data.Common;
using DemoDCProject.DomainLayer.Managers.DataLayer.DataManagers;
using DemoDCProject.Testing.Shared.ServiceLocator;
using DemoDCProject.DomainLayer.Managers.InternalDto;
using DemoDCProject.Testing.Shared.TestClasses;

namespace DemoDCProject.IntegrationTests.DemoDCProject.DomainLayer.Managers.DataLayer.DataManager
{
    [TestClass]
    public class TokenDataManagerTests
    {
        private static TokenDataManagerBase tokenDataManagerUnderTest;
        private static DbConnection dbConnection;

        private static void ExecuteNonQueryOperation(string commandText)
        {
            dbConnection.Open();
            DbTransaction transaction = null;
            DbCommand dbCommand = null;
            try
            {
                transaction = dbConnection.BeginTransaction();
                dbCommand = dbConnection.CreateCommand();
                dbCommand.Transaction = transaction;
                dbCommand.CommandText = commandText;
                dbCommand.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (dbCommand != null) dbCommand.Dispose();
                if (transaction != null) transaction.Dispose();
                dbConnection.Close();
            }
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            const string CONNECTION_STRING_NAME = "demodcprojectDb";

            var configurationProvider = new ConfigurationProviderFake();
            configurationProvider.SetDemoDCDbConnectionInformation(CONNECTION_STRING_NAME, "System.Data.SqlClient", @"Data Source=(localdb)\ProjectsV12;Initial Catalog=DemoDCProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");

            var serviceLocator = new ServiceLocatorUnitTesting();
            serviceLocator.ConfigurationProviderFactory = () => configurationProvider;

            var dbConnectionInformation = serviceLocator.CreateConfigurationProvider().GetDbConnectionInformation(CONNECTION_STRING_NAME);

            serviceLocator.DbConnectionFactory = () =>
            {
                var dbProFactory = DbProviderFactories.GetFactory(dbConnectionInformation.ProviderInvariantName);
                var dbConn = dbProFactory.CreateConnection();
                dbConn.ConnectionString = dbConnectionInformation.ConnectionString;
                return dbConn;
            };

            tokenDataManagerUnderTest = new TokenDataManager(serviceLocator);

            // Create another instance of a dbConnection for the purposes of manipulating data directly 
            var dbProviderFactory = DbProviderFactories.GetFactory(dbConnectionInformation.ProviderInvariantName);
            dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = dbConnectionInformation.ConnectionString;
        }

        private static TokenInputData GetTokenData()
        {
            var guidValue = Guid.NewGuid().ToString("N");

            return new TokenInputData
            {
                TokenNumber = "TokenNumber_" + guidValue,
                Pec = "Pec_" + guidValue,
            };
        }

        [TestMethod]
        [TestCategory("Class Integration Test")]
        public void TokenDataManager_CreateToken_ShouldSucceed()
        {
            // Arrange 
            var tokenInput = GetTokenData();

            // Act           
            try
            {
                var tokenId = tokenDataManagerUnderTest.CreateToken
                    (
                         new Token(tokenInput.Pec, tokenInput.TokenNumber)
                    );

                // Assert
                Assert.AreNotEqual<int>(0, tokenId);
            }
            finally
            {
                // Cleanup
                tokenDataManagerUnderTest.DeleteTokenWithTokenNumber(tokenInput.TokenNumber);
            }

        }
    }
}
