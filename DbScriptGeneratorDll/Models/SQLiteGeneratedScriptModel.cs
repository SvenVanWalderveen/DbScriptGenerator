using DbScriptGeneratorDll.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbScriptGeneratorDll.Models
{
    class SQLiteGeneratedScriptModel : GeneratedScriptModel
    {
        private readonly DatabaseType _dbType;
        private string _tableName;
        private string _sqlScript;
        public SQLiteGeneratedScriptModel()
        {
            _dbType = DatabaseType.SQLite;
        }

        public override DatabaseType DbType
        {
            get { return _dbType; }
        }

        public override string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
        public override string SqlScript
        {
            get { return _sqlScript; }
            set { _sqlScript = value; }
        }
    }
}
