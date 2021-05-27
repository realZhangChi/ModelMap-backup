using AutoMapper;
using ModelMap.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Desktop
{
    public class ModelMapDesktopAutoMapProfile : Profile
    {
        public ModelMapDesktopAutoMapProfile()
        {
            //CreateMap<PropertyModel, PropertyDefineDto>()
            //    .ForMember(des => des.AccessLevel, opt => opt.MapFrom(src => src.AccessLevel))
            //    .ReverseMap()
            //    .ForMember(des => des.Collapse, opt => opt.Ignore())
            //    .ForMember(des => des.CollapseIconStyle, opt => opt.Ignore())
            //    .ForMember(des => des.CollapseStyle, opt => opt.Ignore())
            //    // why automap can not map this property?
            //    .ForMember(des => des.AccessLevel, opt => opt.MapFrom(src => src.AccessLevel));
            //CreateMap<EntityComponentModel, EntityComponentDto>().ReverseMap();
            //CreateMap<EntityComponentModel, CreateEntityComponentDto>();
            //CreateMap<EntityComponentModel, UpdateEntityComponentDto>();

        }
    }
}
