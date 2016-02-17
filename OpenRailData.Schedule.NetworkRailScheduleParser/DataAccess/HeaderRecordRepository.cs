using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class HeaderRecordRepository : BaseRepository<HeaderRecord>, IHeaderRecordRepository
    {
        private readonly ILog Logger = LogManager.GetLogger("Repository.HeaderRecord");

        public HeaderRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(HeaderRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            if (Logger.IsTraceEnabled)
                Logger.Trace($"Inserting new Header record: {record}");

            Add(record);
        }

        public IEnumerable<HeaderRecord> GetRecentUpdates(int count = 1)
        {
            return Find(x => true)
                .OrderByDescending(x => x.DateOfExtract)
                .Take(count);
        }
    }
}