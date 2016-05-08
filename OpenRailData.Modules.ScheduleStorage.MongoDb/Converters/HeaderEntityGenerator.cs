using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    public class HeaderEntityGenerator
    {
        internal static HeaderDocument RecordToDocument(HeaderRecord record)
        {
            var headerRecordEntity = HeaderMapperConfiguration.RecordToDocument().Map<HeaderDocument>(record);

            return headerRecordEntity;
        }

        internal static HeaderRecord DocumentToRecord(HeaderDocument document)
        {
            var headerRecord = HeaderMapperConfiguration.DocumentToRecord().Map<HeaderRecord>(document);

            return headerRecord;
        }
    }
}