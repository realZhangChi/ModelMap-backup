using Microsoft.CodeAnalysis.MSBuild;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.Solution
{
    // TODO: use OmniSharp to handle the solution
    public class CurrentSolution : ICurrentSolution, ISingletonDependency
    {
        private MSBuildWorkspace _workspace;

        public Microsoft.CodeAnalysis.Solution Value => _workspace.CurrentSolution;

        public CurrentSolution()
        {
            _workspace = MSBuildWorkspace.Create();
        }

        public async Task SetAsync(string path)
        {
            // TODO: path valitation
            _workspace.CloseSolution();
            _ = await _workspace.OpenSolutionAsync(path);
        }
    }
}
