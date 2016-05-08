using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    public class ScheduleEntityGenerator
    {
        internal static ScheduleRecordEntity RecordToEntity(ScheduleRecord record)
        {
            var scheduleRecordEntity = ScheduleMapperConfiguration.RecordToEntity().Map<ScheduleRecordEntity>(record);

            return scheduleRecordEntity;
        }

        internal static ScheduleRecord EntityToRecord(ScheduleRecordEntity entity)
        {
            var scheduleRecord = ScheduleMapperConfiguration.EntityToRecord().Map<ScheduleRecord>(entity);

            return scheduleRecord;
        }
    }
}