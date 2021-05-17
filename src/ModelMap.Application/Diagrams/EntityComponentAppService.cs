using System.Threading.Tasks;
using Volo.Abp;

namespace ModelMap.Diagrams
{
    [RemoteService]
    public class EntityComponentAppService : ModelMapAppService, IEntityComponentAppService
    {
        protected IEntityComponentManager Manager => LazyServiceProvider.LazyGetRequiredService<IEntityComponentManager>();

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
    }
}
