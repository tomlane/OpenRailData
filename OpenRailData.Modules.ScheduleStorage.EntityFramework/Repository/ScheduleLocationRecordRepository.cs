using System;
using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class ScheduleLocationRecordRepository : BaseRepository<ScheduleLocationRecord>, IScheduleLocationRecordRepository
    {
        public ScheduleLocationRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            AddRange(records);
        }

        public void DeleteRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            RemoveRange(records);
        }
    }
}