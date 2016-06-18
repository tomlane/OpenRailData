using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class ScheduleLocationRecordRepository : BaseRepository<ScheduleLocationRecord>, IScheduleLocationRecordRepository
    {
        private readonly IScheduleContext _context;

        public ScheduleLocationRecordRepository(IScheduleContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
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

        public async Task<List<ScheduleLocationRecord>> GetLocationsByTiploc(string tiploc)
        {
            if (string.IsNullOrWhiteSpace(tiploc))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(tiploc));

            var records = await _context.GetSet<ScheduleLocationRecordEntity>().Include(x => x.ScheduleRecord).Where(x => x.Tiploc == tiploc).ToListAsync();

            return records.Select(ScheduleLocationEntityGenerator.EntityToRecord).ToList();
        }
    }
}