using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarauderMap.Desktop.Blazor.Components.SolutionTrees
{
    public class NodeModel
    {
        public string Name { get; set; }

        public bool IsFile { get; set; }

        public ICollection<NodeModel> Children { get; set; }
    }
}
