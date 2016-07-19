using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.CommonDatabase;
using OpenRailData.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.ScheduleStorage.EntityFramework.Repository
{
    public class ScheduleRecordRepository : BaseRepository<ScheduleRecordEntity>, IScheduleRecordRepository
    {
        private readonly IScheduleContext _context;

        public ScheduleRecordRepository(IScheduleContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public void InsertRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = ScheduleEntityGenerator.RecordToEntity(record);

            Add(entity);
        }

        public void AmendRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = Find(x =>
                x.TrainUid == record.TrainUid &&
                x.StartDate == record.StartDate &&
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (currentRecord == null)
                return;

            var entity = ScheduleEntityGenerator.RecordToEntity(record);

            currentRecord = entity;

            Add(currentRecord);
        }

        public void DeleteRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToDelete = Find(x => 
                x.TrainUid == record.TrainUid && 
                x.StartDate == record.StartDate && 
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (recordToDelete != null)
                Remove(recordToDelete);
        }

        public Task InsertRecordAsync(ScheduleRecord record)
        {
            throw new NotImplementedException();
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<ScheduleRecord> records)
        {
            throw new NotImplementedException();
        }

        public Task AmendRecordAsync(ScheduleRecord record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(ScheduleRecord record)
        {
            throw new NotImplementedException();
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