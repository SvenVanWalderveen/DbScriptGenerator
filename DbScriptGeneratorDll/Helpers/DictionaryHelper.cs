using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbScriptGeneratorDll.Helpers
{
    internal static class DictionaryHelper
    {
        internal static string GetDbDataTypeByDotNetDataType(this Dictionary<List<Type>, string> dictionary, Type type)
        {
            if(!dictionary.Any())
            {
                return null;
            }
            return dictionary.Where(x => x.Key.Contains(type)).First().Value;
        }
    }
}
