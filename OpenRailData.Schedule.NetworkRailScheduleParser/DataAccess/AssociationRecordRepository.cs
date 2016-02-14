using System;
using System.Linq;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class AssociationRecordRepository : BaseRepository<AssociationRecord>, IAssociationRecordRepository
    {
        public AssociationRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Add(record);
        }

        public void AmendRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord =
                Find(x => x.MainTrainUid == record.MainTrainUid && x.AssocTrainUid == record.AssocTrainUid).FirstOrDefault();

            if (currentRecord == null)
                throw new ArgumentException("Could not find Association Record to amend.");

            currentRecord = record;

            Add(currentRecord);
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
                throw new ArgumentException("Could not find Association Record to delete.");

            Remove(recordToDelete);
        }
    }
}