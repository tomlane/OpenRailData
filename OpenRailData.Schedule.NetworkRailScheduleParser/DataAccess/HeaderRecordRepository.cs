using System;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class HeaderRecordRepository : BaseRepository<HeaderRecord>, IHeaderRecordRepository
    {
        private readonly ScheduleContext _context;

        public HeaderRecordRepository(IScheduleContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context as ScheduleContext;
        }
    }
}