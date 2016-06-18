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

            var currentRecord = Find(x => x.TiplocCode == record.TiplocCode).FirstOrDefault();

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

            var recordToDelete = Find(x => x.TiplocCode == record.TiplocCode).FirstOrDefault();

            if (recordToDelete != null)
                Remove(recordToDelete);
        }

        public void AmendLocationName(string locationName, string tiplocCode)
        {
            if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentNullException(nameof(locationName));

            if (string.IsNullOrWhiteSpace(tiplocCode))
                throw new ArgumentNullException(nameof(tiplocCode));

            var recordToAmend = Find(x => x.TiplocCode == tiplocCode).FirstOrDefault();

            if (recordToAmend == null)
                throw new ArgumentException("Tiploc entity not found");

            recordToAmend.LocationName = locationName;

            Add(recordToAmend);
        }

        public Task InsertRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<TiplocRecord> records)
        {
            throw new NotImplementedException();
        }

        public Task AmendRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task AmendLocationNameAsync(string locationName, string tiplocCode)
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
    }
}