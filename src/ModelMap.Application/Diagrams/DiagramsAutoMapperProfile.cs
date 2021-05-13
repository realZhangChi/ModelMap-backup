using AutoMapper;
using ModelMap.Diagrams;

namespace ModelMap
{
    public class DiagramsAutoMapperProfile : Profile
    {
        public DiagramsAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Position, PositionDto>();
            CreateMap<PropertyDefine, PropertyDefineDto>();
            CreateMap<EntityComponent, EntityComponentDto>();
        }
    }
}
