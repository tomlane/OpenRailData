using AutoMapper;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Mappers
{
    internal class TrainMovementMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainActivation, TrainActivationEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<TrainCancellation, TrainCancellationEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<TrainMovement, TrainMovementEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<TrainReinstatement, TrainReinstatementEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<ChangeOfOrigin, ChangeOfOriginEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
                cfg.CreateMap<ChangeOfIdentity, ChangeOfIdentityEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}