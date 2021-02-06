using System;
using System.Collections.Generic;
using System.Text;

namespace DbScriptGeneratorDll.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ScriptGeneratorPropertyAttribute : Attribute
    {
        private bool primaryKey;
        private bool nullable;

        public virtual bool IsPrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

        public virtual bool IsNullable
        {
            get { return nullable; }
            set { nullable = value; }
        }
    }
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ScriptGeneratorClassAttribute : Attribute
    {
        private string tableName;
        
        public virtual string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
    }
}
