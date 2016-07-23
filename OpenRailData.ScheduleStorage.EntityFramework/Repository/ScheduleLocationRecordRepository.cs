using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.ScheduleStorage.EntityFramework.Repository
{
    public class ScheduleLocationRecordRepository : IScheduleLocationRecordRepository
    {
        private readonly IScheduleContext _context;

        public ScheduleLocationRecordRepository(IScheduleContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public Task InsertMultipleRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entites = records.Select(ScheduleLocationEntityGenerator.RecordToEntity).ToList();

            _context.GetSet<ScheduleLocationRecordEntity>().AddRange(entites);

            return Task.CompletedTask;
        }

        public Task DeleteMultipleRecords(IEnumerable<ScheduleLocationRecord> records)
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