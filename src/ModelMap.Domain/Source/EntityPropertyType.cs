using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Source
{
    public class EntityPropertyType
    {
        public static ICollection<string> Types = new List<string>()
        {
            "bool",
            "byte",
            "sbyte",
            "char",
            "decimal",
            "double",
            "float",
            "int",
            "uint",
            "nint",
            "long",
            "ulong",
            "short",
            "string",
            "ushort"
        };
    }
}
