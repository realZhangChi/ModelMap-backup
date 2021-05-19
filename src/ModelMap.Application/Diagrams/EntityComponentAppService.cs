using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;

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

        public Task DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        public async Task<EntityComponentDto> GetAsync(Guid id)
        {
            var entity = await Repository.GetAsync(id);
            var dto = ObjectMapper.Map<EntityComponent, EntityComponentDto>(
                entity
                );
            return dto;
        }

        public async Task<ICollection<EntityComponentDto>> GetListAsync(Guid solutionId)
        {
            return ObjectMapper.Map<List<EntityComponent>, List<EntityComponentDto>>(
                await Repository.GetListAsync(e => e.SolutionId == solutionId, true));
        }

        public async Task<EntityComponentDto> UpdateAsync(Guid id, UpdateEntityComponentDto input)
        {
            var entity = await Repository.GetAsync(id);
            _ = ObjectMapper.Map(input, entity);
            _ = await Repository.UpdateAsync(entity);
            return ObjectMapper.Map<EntityComponent, EntityComponentDto>(entity);
        }

        public async Task<EntityComponentDto> UpdatePositionAsync(Guid id, PositionDto input)
        {
            var entity = await Repository.GetAsync(id);
            _ = entity.SetPosition(input.Top, input.Left);
            _ = await Repository.UpdateAsync(entity);
            return ObjectMapper.Map<EntityComponent, EntityComponentDto>(entity);
        }
    }
}
