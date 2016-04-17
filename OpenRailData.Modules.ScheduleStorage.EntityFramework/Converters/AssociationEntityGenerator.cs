using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    public class AssociationEntityGenerator
    {
        internal static AssociationRecordEntity RecordToEntity(AssociationRecord record)
        {
            var associationRecordEntity = AssociationMapperConfiguration.RecordToEntity().Map<AssociationRecordEntity>(record);

            return associationRecordEntity;
        }
    }
}