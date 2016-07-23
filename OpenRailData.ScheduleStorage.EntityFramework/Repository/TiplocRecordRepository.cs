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
    public class TiplocRecordRepository : ITiplocRecordRepository 
    {
        private readonly IScheduleContext _context;

        public TiplocRecordRepository(IScheduleContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }
        
        public Task InsertRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = TiplocEntityGenerator.RecordToEntity(record);

            _context.GetSet<TiplocRecordEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task InsertMultipleRecords(IEnumerable<TiplocRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entities = records.Select(TiplocEntityGenerator.RecordToEntity).ToList();

            _context.GetSet<TiplocRecordEntity>().AddRange(entities);

            return Task.CompletedTask;
        }

        public async Task AmendRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = await _context.GetSet<TiplocRecordEntity>().FirstOrDefaultAsync(x => x.TiplocCode == record.TiplocCode);

            if (currentRecord != null)
            {
                var entity = TiplocEntityGenerator.RecordToEntity(record);

                _context.GetSet<TiplocRecordEntity>().Remove(currentRecord);

                _context.GetSet<TiplocRecordEntity>().Add(entity);
            }
        }

        public Task DeleteRecord(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TiplocRecord>> GetAllTiplocs()
        {
            var records = await _context.GetSet<TiplocRecordEntity>().ToListAsync();

            return records.Select(TiplocEntityGenerator.EntityToRecord).ToList();
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