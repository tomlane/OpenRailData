using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.ScheduleStorage.EntityFramework.Repository
{
    public class ScheduleRecordRepository : IScheduleRecordRepository
    {
        private readonly IScheduleContext _context;

        public ScheduleRecordRepository(IScheduleContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public Task InsertRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = ScheduleEntityGenerator.RecordToEntity(record);

            _context.GetSet<ScheduleRecordEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task InsertMultipleRecords(IEnumerable<ScheduleRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entites = records.Select(ScheduleEntityGenerator.RecordToEntity).ToList();

            _context.GetSet<ScheduleRecordEntity>().AddRange(entites);

            return Task.CompletedTask;
        }

        public async Task AmendRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = await 
                _context.GetSet<ScheduleRecordEntity>().Where(x => x.UniqueId == record.UniqueId).FirstOrDefaultAsync();

            if (currentRecord != null)
            {
                var entity = ScheduleEntityGenerator.RecordToEntity(record);

                _context.GetSet<ScheduleRecordEntity>().Remove(currentRecord);

                _context.GetSet<ScheduleRecordEntity>().Add(entity);
            }
        }

        public async Task DeleteRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToDelete = await 
                _context.GetSet<ScheduleRecordEntity>().Where(x => x.UniqueId == record.UniqueId).FirstOrDefaultAsync();

            if (recordToDelete != null)
            {
                _context.GetSet<ScheduleRecordEntity>().Remove(recordToDelete);
            }
        }

        public async Task<IEnumerable<ScheduleRecord>> GetScheduleRecords(string trainUid, DateTime startDate)
        {
            if (string.IsNullOrWhiteSpace(trainUid))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(trainUid));

            var set = _context.GetSet<ScheduleRecordEntity>().Include(x => x.ScheduleLocations);

            var entites = await set.Where(x => x.TrainUid == trainUid && x.StartDate == startDate).ToListAsync();

            return entites.Select(ScheduleEntityGenerator.EntityToRecord);
        }
    }
}