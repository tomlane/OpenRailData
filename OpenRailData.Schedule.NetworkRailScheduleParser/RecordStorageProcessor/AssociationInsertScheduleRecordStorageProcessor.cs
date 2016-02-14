using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class AssociationInsertScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWork _unitOfWork;

        public AssociationInsertScheduleRecordStorageProcessor(IScheduleUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.AAN;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToSave = record as AssociationRecord;

            if (recordToSave == null)
                throw new ArgumentException("Failed to cast record for saving.");

            using (_unitOfWork)
            {
                _unitOfWork.AssociationRecords.Add(recordToSave);

                _unitOfWork.Complete();
            }

            Trace.TraceInformation("Processed a Association Insert Record.");
        }
    }
}