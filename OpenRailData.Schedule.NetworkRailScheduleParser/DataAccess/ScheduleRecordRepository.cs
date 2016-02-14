using System;
using System.Linq;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class ScheduleRecordRepository : BaseRepository<ScheduleRecord>, IScheduleRecordRepository
    {
        public ScheduleRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Add(record);
        }

        public void AmendRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = Find(x => x.TrainUid == record.TrainUid).FirstOrDefault();

            if (currentRecord == null)
                throw new ArgumentException("Could not find Schedule Record to amend.");

            currentRecord = record;

            Add(currentRecord);
        }

        public void DeleteRecord(ScheduleRecord record)
        {
            if (string.IsNullOrWhiteSpace(record.TrainUid))
                throw new ArgumentNullException(nameof(record.TrainUid));

            if (record.DateRunsFrom == null)
                throw new ArgumentNullException(nameof(record.DateRunsFrom));

            if (record.StpIndicator == 0)
                throw new ArgumentNullException(nameof(record.StpIndicator));

            var recordToDelete = Find(x => 
                x.TrainUid == record.TrainUid && 
                x.DateRunsFrom == record.DateRunsFrom && 
                x.StpIndicator == record.StpIndicator)
                .FirstOrDefault();

            if (recordToDelete == null)
                throw new ArgumentException("Could not find Schedule Record to delete.");

            Remove(recordToDelete);
        }
    }
}