using System;
using System.Collections.Generic;
using System.Text;

namespace DbScriptGeneratorDll.Models
{
    class CommandGeneratorFormats
    {
        public string CreateTableFormat { get; set; }
        public string DropTableFormat { get; set; }
        public string ColumnDefinitionFormat { get; set; }
        public string PrimaryKeyConstraintFormat { get; set; }
    }
}
