using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class TiplocRecordRepository : BaseRepository<TiplocRecordEntity>, ITiplocRecordRepository 
    {
        public TiplocRecordRepository(IScheduleContext context) : base(context)
        {
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

            var response = records.Select(tiplocRecordEntity => new TiplocRecord
            {
                CrsCode = tiplocRecordEntity.CrsCode,
                CapitalsIdentification = tiplocRecordEntity.CapitalsIdentification,
                CapriDescription = tiplocRecordEntity.CapriDescription,
                LocationName = tiplocRecordEntity.LocationName,
                Nalco = tiplocRecordEntity.Nalco,
                Nlc = tiplocRecordEntity.Nlc,
                Stanox = tiplocRecordEntity.Stanox,
                TiplocCode = tiplocRecordEntity.TiplocCode
            }).ToList();

            return Task.FromResult(response);
        }
    }
}