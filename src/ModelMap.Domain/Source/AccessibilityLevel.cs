using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Source
{
    public class AccessibilityLevel
    {
        // public > protected internal > protected > internal > private protected > private
        // CS0274: The accessibility modifier of the 'property_accessor' accessor must be more restrictive than the property or indexer 'property'
        // CS0273: Cannot specify accessibility modifiers for both accessors of the property or indexer 'property/indexer
        public static IReadOnlyDictionary<int, string> Levels => new Dictionary<int, string>()
        {
            {0, string.Empty },
            {1, "private" },
            {2, "private protected" },
            {3, "internal" },
            {4, "protected" },
            {5, "protected internal" },
            {6, "public" },
        };
    }
}
