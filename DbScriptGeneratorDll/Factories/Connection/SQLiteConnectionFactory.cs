using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;

namespace DbScriptGeneratorDll.Factories.Connection
{
    class SQLiteConnectionFactory : DbConnectionFactory
    {
        private DbConnection _dbConnection;


        public override DbConnection Connection
        {
            get { return _dbConnection; }
            set { _dbConnection = value; }
        }

        public override ResponseEnvelope CreateConnection(string connectionString)
        {
            try
            {
                if(string.IsNullOrEmpty(connectionString))
                {
                    return new ResponseEnvelope(new Exception("No connectionstring set"));
                }
                if(!connectionString.StartsWith("Data Source=")) {
                    connectionString = string.Format("Data Source={0}", connectionString);
                }

                _dbConnection = new SQLiteConnection(connectionString);
                return new ResponseEnvelope();
            }
            catch (Exception ex)
            {
                return new ResponseEnvelope(ex);
            }
        }

        public override ResponseEnvelope CreateDatabase(string connectionString)
        {
            try
            {
                SQLiteConnection.CreateFile(connectionString);
                return new ResponseEnvelope();
            }
            catch (Exception ex)
            {
                return new ResponseEnvelope(ex);
            }
        }

        public override ResponseEnvelopeWithDataResult<T> ExecuteCommand<T>(string command)
        {
            throw new NotImplementedException();
        }

        public override ResponseEnvelope ExecuteCommand(string command)
        {
            try
            {
                SQLiteConnection connection = Connection as SQLiteConnection;
                connection.Open();
                using SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
                return new ResponseEnvelope();
            }
            catch (Exception ex)
            {
                return new ResponseEnvelope(ex);
            }
        }
    }
}
