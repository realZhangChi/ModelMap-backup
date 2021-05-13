using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;

namespace ModelMap.Solutions
{
    public interface ISolutionAppService : IApplicationService
    {
        Task<SolutionDto> SetPathAsync([NotNull] string fullPath);
    }
}
