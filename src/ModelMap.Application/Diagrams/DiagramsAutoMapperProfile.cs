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
            CreateMap<Position, PositionDto>()
                .ReverseMap();
            CreateMap<PropertyDefine, PropertyDefineDto>()
                // why automap can not map this property?
                .ForMember(des => des.AccessLevel, opt => opt.MapFrom(src => src.AccessLevel))
                .ReverseMap()
                .ForMember(des => des.EntityComponent, opt => opt.Ignore())
                .ForMember(des => des.AccessLevel, opt => opt.MapFrom(src => src.AccessLevel));
            CreateMap<EntityComponent, EntityComponentDto>();
            CreateMap<UpdateEntityComponentDto, EntityComponent>()
                .ForMember(des => des.SolutionId, opt => opt.Ignore())
                .ForMember(des => des.Imports, opt => opt.Ignore())
                .ForMember(des => des.NamespaceBelongingTo, opt => opt.Ignore())
                .ForMember(des => des.ProjectRelativePath, opt => opt.Ignore())
                .ForMember(des => des.Directory, opt => opt.Ignore())
                .ForMember(des => des.BaseClass, opt => opt.Ignore())
                .ForMember(des => des.BaseInterfaces, opt => opt.Ignore());
        }
    }
}
