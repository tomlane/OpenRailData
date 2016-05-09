using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class ScheduleLocationRecordRepository : BaseRepository<ScheduleLocationRecord>, IScheduleLocationRecordRepository
    {
        public ScheduleLocationRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertMultipleRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            AddRange(records);
        }

        public void DeleteMultipleRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            RemoveRange(records);
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMultipleRecordsAsync(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new NotImplementedException();
        }
    }
}