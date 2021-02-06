using DbScriptGeneratorDll.Annotations;
using DbScriptGeneratorDll.Enums;
using DbScriptGeneratorDll.Helpers;
using DbScriptGeneratorDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbScriptGeneratorDll.Factories.Script
{
    class SQLiteCommandGeneratorFactory : CommandGeneratorFactory
    {
        private Dictionary<List<Type>, string> _dataTypeMapping;


        public SQLiteCommandGeneratorFactory()
        {
            _dataTypeMapping = new Dictionary<List<Type>, string>()
            {
                { new List<Type> { typeof(Guid), typeof(string), typeof(DateTime)}, "TEXT" },
                { new List<Type> { typeof(int), typeof(string)}, "INTEGER" },
                { new List<Type> { typeof(double), typeof(string)}, "REAL" }
            };
        }




        public override Dictionary<List<Type>, string> DataTypeMapping
        {
            get { return _dataTypeMapping; }
        }

        public override ResponseEnvelopeWithDataResult<GeneratedScriptModel> CreateScriptModel(DatabaseOperation databaseOperation, Type objectType)
        {
            //Retrieve properties
            string tableName = objectType.GetTableNameFromAttribute();
            List<Tuple<PropertyInfo, ScriptGeneratorPropertyAttribute>> primaryKeys = objectType.GetPrimaryKeysFromAttribute();
            CommandGeneratorParameters parameterModel = new CommandGeneratorParameters(tableName, primaryKeys, DatabaseType.SQLite);
            //Create return object
            SQLiteGeneratedScriptModel returnModel = new SQLiteGeneratedScriptModel()
            {
                TableName = tableName
            };
            switch (databaseOperation)
            {
                case DatabaseOperation.CreateTable:
                    returnModel.SqlScript = GenerateCreateTableScript(parameterModel);
                    break;
                case DatabaseOperation.DropTable:
                    returnModel.SqlScript = GenerateDropTableScript(parameterModel);
                    break;
            }
            return new ResponseEnvelopeWithDataResult<GeneratedScriptModel>(returnModel);
        }

        public override string GenerateCreateTableScript(CommandGeneratorParameters parameters)
        {
            string tableFormat = parameters.Formats.CreateTableFormat;
            string tableName = parameters.TableName;
            List<string> fields = new List<string>();
            List<string> constraints = new List<string>();

            //Primary key
            var pkeyColumns = parameters.Properties.Where(x => x.Item2.IsPrimaryKey);
            foreach (var property in pkeyColumns)
            {
                string propertyName = property.Item1.Name.ToUpper();
                string dbDataType = DataTypeMapping.GetDbDataTypeByDotNetDataType(property.Item1.PropertyType);
                string columnDefinition = string.Format(parameters.Formats.ColumnDefinitionFormat, propertyName, dbDataType, "NOT NULL");
                fields.Add(columnDefinition);
            }

            string pkeyConstraint = string.Format(parameters.Formats.PrimaryKeyConstraintFormat, tableName, string.Join(',', pkeyColumns.Select(x => x.Item1.Name.ToUpper())));
            constraints.Add(pkeyConstraint);


            return string.Format(tableFormat, tableName, string.Join(',', fields), string.Join(',', constraints));
        }

        public override string GenerateDeleteRecordScript(CommandGeneratorParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override string GenerateDropTableScript(CommandGeneratorParameters parameters)
        {
            string tableFormat = parameters.Formats.DropTableFormat;
            string tableName = parameters.TableName;
            return string.Format(tableFormat, tableName);
        }

        public override string GenerateInsertRecordScript(CommandGeneratorParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override string GenerateTableAddColumnScript(CommandGeneratorParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override string GenerateTableRemoveColumnScript(CommandGeneratorParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override string GenerateUpdateRecordScript(CommandGeneratorParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
