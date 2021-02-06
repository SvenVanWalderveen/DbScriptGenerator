using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DbScriptGeneratorDll.Factories.Connection
{
    abstract class DbConnectionFactory
    {
        public abstract DbConnection Connection { get; set; }


        public abstract ResponseEnvelope CreateConnection(string connectionString);
        public abstract ResponseEnvelopeWithDataResult<T> ExecuteCommand<T>(string command);
        public abstract ResponseEnvelope ExecuteCommand(string command);
        public abstract ResponseEnvelope CreateDatabase(string connectionString);


    }
}
