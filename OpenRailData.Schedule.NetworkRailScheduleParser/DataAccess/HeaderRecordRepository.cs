using System;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class HeaderRecordRepository : BaseRepository<HeaderRecord>, IHeaderRecordRepository
    {
        public HeaderRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(HeaderRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Add(record);
        }
    }
}