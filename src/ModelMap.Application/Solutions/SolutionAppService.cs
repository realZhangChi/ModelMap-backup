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
        protected IRepository<Solution> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Solution>>();

        public async Task<SolutionDto> CreateAsync([NotNull] CreateSolutionDto input)
        {
            var solution = new Solution(input.AbsolutePath);
            _ = await Repository.InsertAsync(solution);
            return ObjectMapper.Map<Solution, SolutionDto>(solution);
        }
    }
}
