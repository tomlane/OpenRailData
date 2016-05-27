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
                cfg.CreateMap<SignalMessage, SignalMessageEntity>().ReverseMap();
                cfg.CreateMap<BerthMessage, BerthMessageEntity>().ReverseMap();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}