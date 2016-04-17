using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    internal class ScheduleMapperConfiguration
    {
        internal static IMapper RecordToEntity()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ScheduleRecord, ScheduleRecordEntity>().ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<ScheduleLocationRecord, ScheduleLocationRecordEntity>();
            });

            return config.CreateMapper();
        }
    }
}