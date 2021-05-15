using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModelMap.Diagrams
{
    public interface IEntityComponentAppService : IApplicationService
    {
        Task<EntityComponentDto> CreateAsync(CreateEntityComponentDto input);
    }
}
