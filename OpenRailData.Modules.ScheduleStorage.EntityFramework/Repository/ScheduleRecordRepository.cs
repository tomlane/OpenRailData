using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class ScheduleRecordRepository : BaseRepository<ScheduleRecordEntity>, IScheduleRecordRepository
    {
        public ScheduleRecordRepository(IScheduleContext context) : base(context)
        {
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
                x.DateRunsFrom == record.DateRunsFrom &&
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (currentRecord != null)
            { 
                var entity = ScheduleEntityGenerator.RecordToEntity(record);

                currentRecord = entity;

                Add(currentRecord);
            }
        }

        public void DeleteRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToDelete = Find(x => 
                x.TrainUid == record.TrainUid && 
                x.DateRunsFrom == record.DateRunsFrom && 
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
    }
}