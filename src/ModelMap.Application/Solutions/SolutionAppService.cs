using IdentityServer4.Configuration;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ModelMap.Solutions
{
    [RemoteService]
    public class SolutionAppService : ModelMapAppService, ISolutionAppService
    {
        protected ISolutionRepository Repository => LazyServiceProvider.LazyGetRequiredService<ISolutionRepository>();

        protected ISolutionManager Manager => LazyServiceProvider.LazyGetRequiredService<ISolutionManager>();

        public async Task<SolutionDto> CreateAsync([NotNull] CreateSolutionDto input)
        {
            var solution = await Manager.CreateAsync(input.AbsolutePath);
            _ = await Repository.InsertAsync(solution);
            return ObjectMapper.Map<Solution, SolutionDto>(solution);
        }

        public async Task<PagedResultDto<SolutionDto>> GetListAsync(SolutionPagedResultRequestDto input)
        {
            var count = await Repository.CountAsync(s => s.CreatorId == CurrentUser.Id);
            var list = await Repository.GetListAsync(CurrentUser.Id, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SolutionDto>(count,
                ObjectMapper.Map<List<Solution>, List<SolutionDto>>(list));
        }
    }
}
