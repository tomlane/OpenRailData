using System;
using System.Linq;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class TiplocRecordRepository : BaseRepository<TiplocRecord>, ITiplocRecordRepository 
    {
        public TiplocRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Add(record);
        }

        public void AmendRecord(TiplocRecord newRecord)
        {
            if (newRecord == null)
                throw new ArgumentNullException(nameof(newRecord));

            var currentRecord = Find(x => x.TiplocCode == newRecord.TiplocCode).FirstOrDefault();

            if (currentRecord == null)
                throw new ArgumentException("Could not find a Tiploc Record to update.");

            currentRecord = newRecord;

            Add(currentRecord);
        }

        public void DeleteRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToDelete = Find(x => x.TiplocCode == record.TiplocCode).FirstOrDefault();

            if (recordToDelete == null)
                throw new ArgumentException("Could not find Tiploc Record to delete.");

            Remove(recordToDelete);
        }
    }
}