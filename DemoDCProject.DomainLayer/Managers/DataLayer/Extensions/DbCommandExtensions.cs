using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.DataLayer.Extensions
{
    internal static class DbCommandExtensions
    {
        private static DbParameter InitializeCommandParameter(DbCommand dbCommand, DbType dbType, ParameterDirection parameterDirection, string parameterName, object value)
        {
            var dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.Direction = parameterDirection;
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            return dbParameter;
        }

        public static void AddReturnParameter(this DbCommand dbCommand)
        {
            var dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int32;
            dbParameter.Direction = ParameterDirection.ReturnValue;
            dbParameter.ParameterName = "@Return";
            dbCommand.Parameters.Add(dbParameter);
        }

        public static void AddParameter(this DbCommand dbCommand, DbType dbType, string parameterName, object value)
        {
            var dbParameter = InitializeCommandParameter(dbCommand, dbType, ParameterDirection.Input, parameterName, value);
            dbCommand.Parameters.Add(dbParameter);
        }

        public static void AddParameter(this DbCommand dbCommand, DbType dbType, string parameterName, object value, int size)
        {
            var dbParameter = InitializeCommandParameter(dbCommand, dbType, ParameterDirection.Input, parameterName, value);
            dbParameter.Size = size;
            dbCommand.Parameters.Add(dbParameter);
        }
    }
}
