using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

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