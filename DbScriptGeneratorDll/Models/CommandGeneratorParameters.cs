using DbScriptGeneratorDll.Annotations;
using DbScriptGeneratorDll.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DbScriptGeneratorDll.Models
{
    internal class CommandGeneratorParameters
    {
        public string TableName { get; set; }
        public List<Tuple<PropertyInfo, ScriptGeneratorPropertyAttribute>> Properties { get; set; }
        public CommandGeneratorFormats Formats { get; set; }

        internal CommandGeneratorParameters(string tablename, List<Tuple<PropertyInfo, ScriptGeneratorPropertyAttribute>> props, DatabaseType dbType)
        {
            if(!string.IsNullOrEmpty(tablename))
            {
                TableName = tablename.ToUpper();
            }
            else
            {
                TableName = null;
            }
            Properties = props;
            SetFormats(dbType);
        }

        internal void SetFormats(DatabaseType dbType)
        {
            switch(dbType)
            {
                case DatabaseType.SQLite:
                    this.Formats = new CommandGeneratorFormats()
                    {
                        CreateTableFormat = "CREATE TABLE IF NOT EXISTS {0} ({1}, {2})", //0 = tablename, 1 = columndefintions, 2 = constraints
                        DropTableFormat = "DROP TABLE IF EXISTS {0}", //0 = tablename
                        ColumnDefinitionFormat = "{0} {1} {2}", //0 = name of column, 1 = datatype, 2 = Nullable?
                        PrimaryKeyConstraintFormat = "CONSTRAINT PK_{0} PRIMARY KEY ({1})" //0 = tablename, 1 = pkey columns
                    };
                    break;
            }
            
        }
    }
}
