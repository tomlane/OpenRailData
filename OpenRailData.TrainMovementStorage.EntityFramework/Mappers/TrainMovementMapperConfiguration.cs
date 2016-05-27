using AutoMapper;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementStorage.EntityFramework.Entites;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Mappers
{
    internal class TrainMovementMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainActivation, TrainActivationEntity>().ReverseMap();
                cfg.CreateMap<TrainCancellation, TrainCancellationEntity>().ReverseMap();
                cfg.CreateMap<TrainMovement, TrainMovementEntity>().ReverseMap();
                cfg.CreateMap<TrainReinstatement, TrainReinstatementEntity>().ReverseMap();
                cfg.CreateMap<ChangeOfOrigin, ChangeOfOriginEntity>().ReverseMap();
                cfg.CreateMap<ChangeOfIdentity, ChangeOfIdentityEntity>().ReverseMap();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}