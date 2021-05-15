using AutoMapper;
using ModelMap.Desktop.Models;
using ModelMap.Diagrams;
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
            CreateMap<PropertyModel, PropertyDefineDto>()
                .ReverseMap()
                .ForMember(des => des.Collapse, opt => opt.Ignore())
                .ForMember(des => des.CollapseIconStyle, opt => opt.Ignore())
                .ForMember(des => des.CollapseStyle, opt => opt.Ignore());
            CreateMap<EntityComponentModel, EntityComponentDto>().ReverseMap();
            CreateMap<EntityComponentModel, CreateEntityComponentDto>();

        }
    }
}
