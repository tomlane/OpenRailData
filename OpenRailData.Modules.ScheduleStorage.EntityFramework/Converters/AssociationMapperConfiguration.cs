using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    internal class AssociationMapperConfiguration
    {
        internal static IMapper RecordToEntity()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AssociationRecord, AssociationRecordEntity>());

            return config.CreateMapper();
        }
    }
}