using System;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class ScheduleLocationRecordRepository : BaseRepository<ScheduleLocationRecord>, IScheduleLocationRecordRepository
    {
        public ScheduleLocationRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void SaveRecord(ScheduleLocationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Add(record);
        }
    }
}