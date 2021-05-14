using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ModelMap.Solutions
{
    public interface ISolutionAppService : IApplicationService
    {
        Task<SolutionDto> CreateAsync([NotNull] CreateSolutionDto input);

        Task<PagedResultDto<SolutionDto>> GetListAsync(SolutionPagedResultRequestDto input);
    }
}
