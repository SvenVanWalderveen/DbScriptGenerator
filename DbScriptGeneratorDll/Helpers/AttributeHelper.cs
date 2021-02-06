using DbScriptGeneratorDll.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbScriptGeneratorDll.Helpers
{
    internal static class AttributeHelper
    {
        internal static List<Tuple<PropertyInfo, ScriptGeneratorPropertyAttribute>> GetPropertiesWithAttributes(this Type objectType)
        {
            return objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => Attribute.IsDefined(x, typeof(ScriptGeneratorPropertyAttribute))).Select(x => Tuple.Create(x, x.GetCustomAttribute<ScriptGeneratorPropertyAttribute>())).ToList();
        }

        internal static string GetTableNameFromAttribute(this Type objectType)
        {
            if (Attribute.IsDefined(objectType, typeof(ScriptGeneratorClassAttribute)))
            {
                ScriptGeneratorClassAttribute attribute = objectType.GetCustomAttribute<ScriptGeneratorClassAttribute>();
                if(string.IsNullOrEmpty(attribute.TableName))
                {
                    return objectType.Name;
                }

                return attribute.TableName;
            }
            else
            {
                return objectType.Name;
            }
        }

        internal static List<Tuple<PropertyInfo, ScriptGeneratorPropertyAttribute>> GetPrimaryKeysFromAttribute(this Type objectType)
        {
            return objectType.GetPropertiesWithAttributes().Where(x => x.Item2.IsPrimaryKey).ToList();
        }
    }
}
