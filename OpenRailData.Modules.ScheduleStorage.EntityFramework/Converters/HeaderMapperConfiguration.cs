using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    internal class HeaderMapperConfiguration
    {
        internal static IMapper RecordToEntity()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HeaderRecord, HeaderRecordEntity>());

            return config.CreateMapper();
        }

        internal static IMapper EntityToRecord()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HeaderRecord, HeaderRecordEntity>());

            return config.CreateMapper();
        }
    }
}