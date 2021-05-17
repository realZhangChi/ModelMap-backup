using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Diagrams
{
    public interface IEntityComponentManager
    {
        Task<EntityComponent> CreateAsync(
            Guid solutionId,
            double top,
            double left,
            ICollection<string> imports,
            [NotNull] string namespaceBeloningTo,
            [NotNull] string projectRelativePath,
            [NotNull] string directory,
            [NotNull] string name,
            string baseClass,
            ICollection<string> baseInterfaces);
    }
}
