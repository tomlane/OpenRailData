using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class AssociationRecordRepository : BaseRepository<AssociationRecord>, IAssociationRecordRepository
    {
        public AssociationRecordRepository(IScheduleContext context) : base(context)
        {
        }
    }
}