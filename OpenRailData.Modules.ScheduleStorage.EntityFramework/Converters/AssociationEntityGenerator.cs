using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.NetworkRailEntites.Records;

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