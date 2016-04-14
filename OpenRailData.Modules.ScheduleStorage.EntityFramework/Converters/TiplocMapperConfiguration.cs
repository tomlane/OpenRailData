using AutoMapper;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    internal class TiplocMapperConfiguration
    {
        internal static IMapper RecordToEntity()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TiplocRecord, TiplocRecordEntity>());

            return config.CreateMapper();
        }
    }
}