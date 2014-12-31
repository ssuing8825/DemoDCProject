using DemoDCProject.DomainLayer.DataLayer.Extensions;
using DemoDCProject.DomainLayer.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.DataLayer.DataManagers.CommandFactories
{
    internal static class CommandFactoryForTokenDataManager
    {
        public static DbCommand CreateCommandForCreateToken(DbConnection dbConnection, Token token)
        {
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "CreateToken";
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.AddReturnParameter();
            dbCommand.AddParameter(DbType.String, "@Pec", token.Pec, 50);
            dbCommand.AddParameter(DbType.String, "@TokenNumber", token.TokenNumber, 50);
            return dbCommand;
        }
    }
}
