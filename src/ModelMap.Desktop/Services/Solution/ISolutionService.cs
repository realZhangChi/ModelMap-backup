using JetBrains.Annotations;
using ModelMap.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.Solution
{
    public interface ISolutionService
    {
        // TODO: Create SolutionModel
        Task<SolutionTreeDto> GetSolutionModelAsync([NotNull] string path);

        Task<string> GetNamespaceAsync([NotNull] string csFileDirectory);

        Task<string> GetProjectRelativePathAsync([NotNull] string path);
    }
}
