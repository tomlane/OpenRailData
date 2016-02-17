using System;
using System.Linq;
using Common.Logging;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class ScheduleRecordRepository : BaseRepository<ScheduleRecord>, IScheduleRecordRepository
    {
        private readonly ILog Logger = LogManager.GetLogger("Repository.ScheduleRecord");

        public ScheduleRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            if (Logger.IsTraceEnabled)
                Logger.Trace($"Inserting new Schedule record: {record}");

            Add(record);
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

            if (currentRecord == null)
            {
                if (Logger.IsWarnEnabled)
                    Logger.Warn($"Failed to find Schedule record to amend. Criteria: {record}");
            }
            else
            {
                if (Logger.IsTraceEnabled)
                    Logger.Trace($"Amending Schedule record: {currentRecord}. New record: {record}");

                currentRecord = record;

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

            if (recordToDelete == null)
            {
                if (Logger.IsWarnEnabled)
                    Logger.Warn($"Failed to find Schedule record to delete. Criteria: {record}");
            }
            else
            {
                if (Logger.IsTraceEnabled)
                    Logger.Trace($"Deleting Schedule record: {recordToDelete}. Criteria: {record}");

                Remove(recordToDelete);
            }
        }
    }
}