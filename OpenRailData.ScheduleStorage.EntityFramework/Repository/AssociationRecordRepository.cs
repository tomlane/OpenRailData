using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.CommonDatabase;
using OpenRailData.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;
using System.Linq;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.ScheduleStorage.EntityFramework.Repository
{
    public class AssociationRecordRepository : BaseRepository<AssociationRecordEntity>, IAssociationRecordRepository
    {
        public AssociationRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entityRecord = AssociationEntityGenerator.RecordToEntity(record);

            Add(entityRecord);
        }

        public void AmendRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = Find(x =>
                x.MainTrainUid == record.MainTrainUid &&
                x.AssocTrainUid == record.AssocTrainUid &&
                x.StartDate == record.StartDate &&
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (currentRecord != null)
            {
                var entityRecord = AssociationEntityGenerator.RecordToEntity(record);

                currentRecord = entityRecord;

                Add(currentRecord);
            }
        }

        public void DeleteRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToDelete = Find(x => 
                x.MainTrainUid == record.MainTrainUid && 
                x.AssocTrainUid == record.AssocTrainUid &&
                x.StartDate == record.StartDate && 
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (recordToDelete != null)
                Remove(recordToDelete);
        }

        public Task InsertRecordAsync(AssociationRecord record)
        {
            throw new NotImplementedException();
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<AssociationRecord> records)
        {
            throw new NotImplementedException();
        }

        public Task AmendRecordAsync(AssociationRecord record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(AssociationRecord record)
        {
            throw new NotImplementedException();
        }
    }
}