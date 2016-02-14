using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class TiplocRecordRepository : BaseRepository<TiplocRecord>, ITiplocRecordRepository 
    {
        public TiplocRecordRepository(IScheduleContext context) : base(context)
        {
        }
    }
}