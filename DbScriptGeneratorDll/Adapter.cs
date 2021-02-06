using DbScriptGeneratorDll.Enums;
using DbScriptGeneratorDll.Factories;
using DbScriptGeneratorDll.Factories.Connection;
using DbScriptGeneratorDll.Factories.Script;
using DbScriptGeneratorDll.Models;
using System;

namespace DbScriptGeneratorDll
{
    public static class Adapter
    {
        private static DatabaseType _currentDatabaseType;
        private static DbConnectionFactory _dbConnectionFactory;
        private static CommandGeneratorFactory _commandGeneratorFactory;



        private static DbConnectionFactory GetDbConnectionFactory(DatabaseType databaseType)
        {
            
            if(_dbConnectionFactory == null)
            {
                CreateNewDbConnectionFactory(databaseType);
            }
            else
            {
                if(_currentDatabaseType != databaseType)
                {
                    CreateNewDbConnectionFactory(databaseType);
                }
            }
            _currentDatabaseType = databaseType;
            return _dbConnectionFactory;
        }
        private static void CreateNewDbConnectionFactory(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.SQLite:
                    _dbConnectionFactory = new SQLiteConnectionFactory();
                    break;
                default:
                    break;
            }
        }
        private static CommandGeneratorFactory GetCommandGeneratorFactory(DatabaseType databaseType)
        {

            if (_commandGeneratorFactory == null)
            {
                CreateNewCommandGeneratorFactory(databaseType);
            }
            else
            {
                if (_currentDatabaseType != databaseType)
                {
                    CreateNewCommandGeneratorFactory(databaseType);
                }
            }
            _currentDatabaseType = databaseType;
            return _commandGeneratorFactory;
        }
        private static void CreateNewCommandGeneratorFactory(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.SQLite:
                    _commandGeneratorFactory = new SQLiteCommandGeneratorFactory();
                    break;
                default:
                    break;
            }
        }


        #region exposed methods
        public static ResponseEnvelope SetupConnectionWithDatabase(string connectionString, DatabaseType dbType)
        {
            return GetDbConnectionFactory(dbType).CreateConnection(connectionString);
        }
        public static ResponseEnvelope ExecuteCommand(string command, DatabaseType dbType)
        {
            return GetDbConnectionFactory(dbType).ExecuteCommand(command);
        }

        public static ResponseEnvelopeWithDataResult<GeneratedScriptModel> GenerateCode(DatabaseOperation operation, DatabaseType dbType, Type objectType)
        {
            return GetCommandGeneratorFactory(dbType).CreateScriptModel(operation, objectType);
        }
        public static ResponseEnvelope CreateDatabase(string connectionString, DatabaseType dbType)
        {
            return GetDbConnectionFactory(dbType).CreateDatabase(connectionString);
        }


        #endregion
    }
}
