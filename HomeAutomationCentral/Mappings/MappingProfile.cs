using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using HomeAutomationCentral.Domain.Entities;
using HomeAutomationCentral.Models;

namespace HomeAutomationCentral.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Device, DeviceModel>().ForPath(d => d.AreaId, o => o.MapFrom(s => s.Area.AreaId));
            CreateMap<DeviceModel, Device>().ForMember((src) => src.Area, opts => opts.Condition((src, dst, srcmember) => srcmember != null));

            CreateMap<Area, AreaModel>();
            CreateMap<AreaModel, Area>();

            CreateMap<EndpointType, EndpointTypeModel>().ConvertUsingEnumMapping(opt => opt.MapValue(EndpointType.Hue, EndpointTypeModel.Hue));
            CreateMap<EndpointTypeModel, EndpointType>().ConvertUsingEnumMapping(opt => opt.MapValue(EndpointTypeModel.Hue, EndpointType.Hue));


            CreateMap<EndpointType, EndpointTypeModel>().ConvertUsingEnumMapping(opt => opt.MapValue(EndpointType.ESP, EndpointTypeModel.ESP));
            CreateMap<EndpointTypeModel, EndpointType>().ConvertUsingEnumMapping(opt => opt.MapValue(EndpointTypeModel.ESP, EndpointType.ESP));
        }

    }
}
