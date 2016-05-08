using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    public class ScheduleEntityGenerator
    {
        internal static ScheduleDocument RecordToDocument(ScheduleRecord record)
        {
            var scheduleRecordEntity = ScheduleMapperConfiguration.RecordToDocument().Map<ScheduleDocument>(record);

            return scheduleRecordEntity;
        }

        internal static ScheduleRecord DocumentToRecord(ScheduleDocument document)
        {
            var scheduleRecord = ScheduleMapperConfiguration.DocumentToRecord().Map<ScheduleRecord>(document);

            return scheduleRecord;
        }
    }
}