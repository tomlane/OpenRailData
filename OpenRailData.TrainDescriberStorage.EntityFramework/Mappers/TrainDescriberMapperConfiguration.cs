using AutoMapper;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.TrainDescriberStorage.EntityFramework.Entities;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Mappers
{
    internal class TrainDescriberMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignalMessage, SignalMessageEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<BerthMessage, BerthMessageEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}