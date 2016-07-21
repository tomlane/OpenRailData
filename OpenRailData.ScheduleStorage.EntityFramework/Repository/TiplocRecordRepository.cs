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
    public class TiplocRecordRepository : BaseRepository<TiplocRecordEntity>, ITiplocRecordRepository 
    {
        private readonly IScheduleContext _context;

        public TiplocRecordRepository(IScheduleContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public void InsertRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = TiplocEntityGenerator.RecordToEntity(record);

            Add(entity);
        }

        public void AmendRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = Find(x => x.TiplocCode == record.TiplocCode).First();

            if (currentRecord != null)
            {
                var entity = TiplocEntityGenerator.RecordToEntity(record);

                currentRecord = entity;

                Add(currentRecord);
            }
        }

        public void DeleteRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToDelete = Find(x => x.TiplocCode == record.TiplocCode).First();

            if (recordToDelete != null)
                Remove(recordToDelete);
        }

        public Task InsertRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<TiplocRecord> records)
        {
            throw new NotImplementedException();
        }

        public async Task AmendRecordAsync(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = await _context.GetSet<TiplocRecordEntity>().FirstOrDefaultAsync(x => x.TiplocCode == record.TiplocCode);

            if (currentRecord != null)
            {
                var entity = TiplocEntityGenerator.RecordToEntity(record);

                Remove(currentRecord);

                currentRecord = entity;

                Add(entity);
            }
        }

        public Task DeleteRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task<List<TiplocRecord>> GetAllTiplocs()
        {
            var records = GetAll();

            var tiplocRecords = records.Select(TiplocEntityGenerator.EntityToRecord).ToList();

            return Task.FromResult(tiplocRecords);
        }

        public async Task<List<TiplocRecord>> GetTiplocsByStanox(string stanox)
        {
            if (string.IsNullOrWhiteSpace(stanox))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(stanox));

            var entities = await _context.GetSet<TiplocRecordEntity>().Where(x => x.Stanox == stanox).ToListAsync();
            
            return entities.Select(TiplocEntityGenerator.EntityToRecord).ToList();
        }

        public async Task<List<TiplocRecord>> GetTiplocsByCrs(string crs)
        {
            if (string.IsNullOrWhiteSpace(crs))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(crs));

            var entites = await _context.GetSet<TiplocRecordEntity>().Where(x => x.CrsCode == crs).ToListAsync();

            return entites.Select(TiplocEntityGenerator.EntityToRecord).ToList();
        }

        public async Task<TiplocRecord> GetTiplocByTiplocCode(string tiplocCode)
        {
            if (string.IsNullOrWhiteSpace(tiplocCode))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(tiplocCode));

            var entity =
                await _context.GetSet<TiplocRecordEntity>().FirstOrDefaultAsync(x => x.TiplocCode == tiplocCode);

            if (entity != null)
                return TiplocEntityGenerator.EntityToRecord(entity);

            return null;
        }
    }
}