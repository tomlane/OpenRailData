using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    public class TiplocEntityGenerator
    {
        internal static TiplocRecordEntity RecordToEntity(TiplocRecord record)
        {
            var tiplocRecordEntity = TiplocMapperConfiguration.RecordToEntity().Map<TiplocRecordEntity>(record);

            return tiplocRecordEntity;
        }
    }
}