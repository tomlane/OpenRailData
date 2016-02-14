using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class ScheduleRecordRepository : BaseRepository<ScheduleRecord>, IScheduleRecordRepository
    {
        public ScheduleRecordRepository(IScheduleContext context) : base(context)
        {
        }
    }
}