using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    public class ScheduleEntityGenerator
    {
        internal static ScheduleRecordEntity RecordToEntity(ScheduleRecord record)
        {
            var scheduleRecordEntity = ScheduleMapperConfiguration.RecordToEntity().Map<ScheduleRecordEntity>(record);

            return scheduleRecordEntity;
        }
    }
}