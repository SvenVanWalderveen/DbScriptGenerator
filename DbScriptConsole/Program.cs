using DbScriptGeneratorDll;
using DbScriptGeneratorDll.Annotations;
using DbScriptGeneratorDll.Enums;
using DbScriptGeneratorDll.Models;
using System;

namespace DbScriptConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Adapter.CreateDatabase(@"C:\Users\Svenv\Documents\ScaleModelApp\Testdb.sqlite", DatabaseType.SQLite);
            //Adapter.SetupConnectionWithDatabase(@"C:\Users\Svenv\Documents\ScaleModelApp\Testdb.sqlite", DatabaseType.SQLite);
            ////DbScriptGeneratorDll.Adapter.ExecuteCommand("DROP TABLE IF EXISTS PART", DatabaseType.SQLite);
            ////DbScriptGeneratorDll.Adapter.CreateDatabase(null, @"C:\Users\Svenv\Documents\ScaleModelApp\Testdb.sqlite", DatabaseType.SQLite);
            ////ResponseEnvelopeWithDataResult<GeneratedScriptModel> result = Adapter.GenerateCode(DatabaseOperation.CreateTable, DatabaseType.SQLite, typeof(TestObject));
            //ResponseEnvelopeWithDataResult<GeneratedScriptModel> result = Adapter.GenerateCode(DatabaseOperation.DropTable, DatabaseType.SQLite, typeof(TestObject));
            //if (result.CallSuccessfull)
            //{
            //    Adapter.ExecuteCommand(result.DataResult.SqlScript, DatabaseType.SQLite);
            //}
        }
    }

    [ScriptGeneratorClass(TableName = "Test")]
    class TestObject
    {
        [ScriptGeneratorProperty(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
