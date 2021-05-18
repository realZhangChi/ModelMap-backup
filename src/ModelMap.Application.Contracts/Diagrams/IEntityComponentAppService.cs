using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModelMap.Diagrams
{
    public interface IEntityComponentAppService : IApplicationService
    {
        Task<EntityComponentDto> CreateAsync(CreateEntityComponentDto input);

        // TODO: get list by cavas viewport center
        Task<ICollection<EntityComponentDto>> GetListAsync(Guid solutionId);
    }
}
