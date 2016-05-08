using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    public class TiplocEntityGenerator
    {
        internal static TiplocDocument RecordToDocument(TiplocRecord record)
        {
            var document = TiplocMapperConfiguration.RecordToDocument().Map<TiplocDocument>(record);

            return document;
        }

        internal static TiplocRecord DocumentToRecord(TiplocDocument document)
        {
            var tiplocRecord = TiplocMapperConfiguration.DocumentToRecord().Map<TiplocRecord>(document);

            return tiplocRecord;
        }
    }
}