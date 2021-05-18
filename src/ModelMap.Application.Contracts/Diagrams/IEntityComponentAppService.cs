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

        Task<EntityComponentDto> GetAsync(Guid id);

        Task<EntityComponentDto> UpdateAsync(Guid id, UpdateEntityComponentDto input);

        Task DeleteAsync(Guid id);
    }
}
