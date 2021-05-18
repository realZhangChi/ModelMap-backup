using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace ModelMap.Diagrams
{
    [RemoteService]
    public class EntityComponentAppService : ModelMapAppService, IEntityComponentAppService
    {
        protected IEntityComponentManager Manager => LazyServiceProvider.LazyGetRequiredService<IEntityComponentManager>();
        protected IEntityComponentRepository Repository => LazyServiceProvider.LazyGetRequiredService<IEntityComponentRepository>();

        public async Task<EntityComponentDto> CreateAsync(CreateEntityComponentDto input)
        {
            var entity = await Manager.CreateAsync(
                input.SolutionId,
                input.Position.Top,
                input.Position.Left,
                input.Imports,
                input.NamespaceBelongingTo,
                input.ProjectRelativePath,
                input.Directory,
                input.Name,
                input.BaseClass,
                input.BaseInterfaces);

            if (input.Properties is { Count: > 0 })
            {
                foreach (var property in input.Properties)
                {
                    entity.AddProperty(
                        GuidGenerator.Create(),
                        property.AccessLevel,
                        property.Type,
                        property.Name,
                        property.GetAccessLevel,
                        property.SetAccessLevel);
                }
            }

            return ObjectMapper.Map<EntityComponent, EntityComponentDto>(entity);
        }

        public async Task<ICollection<EntityComponentDto>> GetListAsync(Guid solutionId)
        {
            return ObjectMapper.Map<List<EntityComponent>, List<EntityComponentDto>>(
                await Repository.GetListAsync(e => e.SolutionId == solutionId, true));
        }
    }
}
