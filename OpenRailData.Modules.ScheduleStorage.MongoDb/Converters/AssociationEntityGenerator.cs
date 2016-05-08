using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    public class AssociationEntityGenerator
    {
        internal static AssociationDocument RecordToDocument(AssociationRecord record)
        {
            var document = AssociationMapperConfiguration.RecordToDocument().Map<AssociationDocument>(record);

            return document;
        }

        internal static AssociationRecord DocumentToRecord(AssociationDocument document)
        {
            var associationRecord = AssociationMapperConfiguration.DocumentToRecord().Map<AssociationRecord>(document);

            return associationRecord;
        }
    }
}