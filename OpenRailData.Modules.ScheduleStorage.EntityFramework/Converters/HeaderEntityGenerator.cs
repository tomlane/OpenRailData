using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    public class HeaderEntityGenerator
    {
        internal static HeaderRecordEntity RecordToEntity(HeaderRecord record)
        {
            var headerRecordEntity = HeaderMapperConfiguration.RecordToEntity().Map<HeaderRecordEntity>(record);

            return headerRecordEntity;
        }

        internal static HeaderRecord EntityToRecord(HeaderRecordEntity entity)
        {
            var headerRecord = HeaderMapperConfiguration.EntityToRecord().Map<HeaderRecord>(entity);

            return headerRecord;
        }
    }
}