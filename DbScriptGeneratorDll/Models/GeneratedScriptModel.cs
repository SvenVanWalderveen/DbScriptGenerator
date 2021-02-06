using DbScriptGeneratorDll.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbScriptGeneratorDll.Models
{
    public abstract class GeneratedScriptModel
    {
        public abstract DatabaseType DbType { get; }
        public abstract string TableName { get; set; }
        public abstract string SqlScript { get; set; }
    }
}
