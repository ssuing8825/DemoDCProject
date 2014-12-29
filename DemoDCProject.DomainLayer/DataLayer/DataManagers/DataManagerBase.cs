using DemoDCProject.DomainLayer.Extensions;
using DemoDCProject.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoDCProject.DomainLayer.DataLayer.DataManagers
{
    internal delegate DbCommand CommandFactory<TCommandParameters>(DbConnection dbConnection, TCommandParameters commandParameters);
    internal delegate DbCommand CommandFactoryWithSpName<TCommandParameters>(DbConnection dbConnection, string storedProcedureName, TCommandParameters commandParameters);
    internal delegate DbCommand CommandFactoryForSingleParameter<TCommandParameterValue>(DbConnection dbConnection, string storedProcedureName, DbType parameterType, string parameterName, TCommandParameterValue commandParameterValue, int parameterSize = 0);

    internal delegate TResult ModelAdapter<TResult>(DbDataReader dbDataReader);

    internal class DataManagerBase
    {
        private static string CONNECTION_STRING_NAME_DEMODC= "demoDCProject";

        private static void ExecuteNonQueryUsingTransaction(DbConnection dbConnection, DbCommand dbCommand)
        {
            dbConnection.Open();
            DbTransaction transaction = null;
            try
            {
                transaction = dbConnection.BeginTransaction();
                dbCommand.Transaction = transaction;
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
                dbCommand.DisposeIfNotNull();
                transaction.DisposeIfNotNull();
                dbConnection.Close();
            }
        }

        protected static DbConnection GetDbConnectionDemoDCProject(ServiceLocatorBase serviceLocator)
        {
            return serviceLocator.CreateDbConnection(CONNECTION_STRING_NAME_DEMODC);
        }

        protected static void ExecuteNonQueryUsingTransaction<TCommandParameters>(DbConnection dbConnection, CommandFactory<TCommandParameters> commandFactory, TCommandParameters commandParameters)
        {
            ExecuteNonQueryUsingTransaction(dbConnection, commandFactory(dbConnection, commandParameters));
        }

        protected static TResult ExecuteNonQueryUsingTransactionAndReturnValue<TCommandParameters, TResult>(DbConnection dbConnection, CommandFactory<TCommandParameters> commandFactory, TCommandParameters commandParameters)
        {
            dbConnection.Open();
            DbCommand dbCommand = null;
            DbTransaction transaction = null;
            try
            {
                dbCommand = commandFactory(dbConnection, commandParameters);
                transaction = dbConnection.BeginTransaction();
                dbCommand.Transaction = transaction;

                dbCommand.ExecuteNonQuery();
                TResult result = (TResult)dbCommand.Parameters[0].Value;

                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                dbCommand.DisposeIfNotNull();
                transaction.DisposeIfNotNull();
                dbConnection.Close();
            }
        }

        protected static TResult ExecuteReaderUsingTransactionAndAdaptToModelWithPossibleNull<TCommandParameters, TResult>(DbConnection dbConnection, CommandFactory<TCommandParameters> commandFactory, TCommandParameters commandParameters, ModelAdapter<TResult> modelAdapter)
        {
            dbConnection.Open();
            DbTransaction transaction = null;
            DbCommand dbCommand = null;
            DbDataReader dbDataReader = null;
            try
            {
                transaction = dbConnection.BeginTransaction();
                dbCommand = commandFactory(dbConnection, commandParameters);
                dbCommand.Transaction = transaction;

                dbDataReader = dbCommand.ExecuteReader();
                TResult result = dbDataReader.Read() ? modelAdapter(dbDataReader) : default(TResult);

                dbDataReader.Close();
                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                dbDataReader.DisposeIfNotNull();
                dbCommand.DisposeIfNotNull();
                transaction.DisposeIfNotNull();
                dbConnection.Close();
            }
        }

        protected static TResult ExecuteReaderUsingTransactionAndAdaptToModel<TCommandParameters, TResult>(DbConnection dbConnection, CommandFactory<TCommandParameters> commandFactory, TCommandParameters commandParameters, ModelAdapter<TResult> modelAdapter)
        {
            dbConnection.Open();
            DbTransaction transaction = null;
            DbCommand dbCommand = null;
            DbDataReader dbDataReader = null;
            try
            {
                transaction = dbConnection.BeginTransaction();
                dbCommand = commandFactory(dbConnection, commandParameters);
                dbCommand.Transaction = transaction;

                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                TResult result = modelAdapter(dbDataReader);

                dbDataReader.Close();
                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                dbDataReader.DisposeIfNotNull();
                dbCommand.DisposeIfNotNull();
                transaction.DisposeIfNotNull();
                dbConnection.Close();
            }
        }

        protected static TResult ExecuteReaderAndAdaptToModelWithPossibleNull<TCommandParameters, TResult>(DbConnection dbConnection, CommandFactory<TCommandParameters> commandFactory, TCommandParameters commandParameters, ModelAdapter<TResult> modelAdapter)
        {
            dbConnection.Open();
            DbCommand dbCommand = null;
            DbDataReader dbDataReader = null;
            try
            {
                dbCommand = commandFactory(dbConnection, commandParameters);
                dbDataReader = dbCommand.ExecuteReader();
                return dbDataReader.Read() ? modelAdapter(dbDataReader) : default(TResult);
            }
            finally
            {
                dbDataReader.DisposeIfNotNull();
                dbCommand.DisposeIfNotNull();
                dbConnection.Close();
            }
        }
    }
}
