using System;
using System.Linq;
using Common.Logging;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class AssociationRecordRepository : BaseRepository<AssociationRecordEntity>, IAssociationRecordRepository
    {
        private readonly ILog Logger = LogManager.GetLogger("Repository.AssociationRecordEntity");

        public AssociationRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            if (Logger.IsTraceEnabled)
                Logger.Trace($"Inserting new Association record: {record} ");

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
                x.DateFrom == record.DateFrom &&
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (currentRecord == null)
            {
                if (Logger.IsWarnEnabled)
                    Logger.Warn($"Failed to find Assocation record to amend. Criteria: {record}");
            }
            else
            {
                if (Logger.IsTraceEnabled)
                    Logger.Trace($"Amending Association record: {currentRecord}. New record: {record}");

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
                x.DateFrom == record.DateFrom && 
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (recordToDelete == null)
            {
                if (Logger.IsWarnEnabled)
                    Logger.Warn($"Failed to find Assocation record to delete. Criteria: {record}");
            }
            else
            {
                if (Logger.IsTraceEnabled)
                    Logger.Trace($"Deleting Association record: {recordToDelete}. Criteria: {record}");

                Remove(recordToDelete);
            }
        }
    }
}