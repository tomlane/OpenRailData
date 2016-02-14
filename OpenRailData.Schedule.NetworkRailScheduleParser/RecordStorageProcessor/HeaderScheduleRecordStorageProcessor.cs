using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class HeaderScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWork _unitOfWork;

        public HeaderScheduleRecordStorageProcessor(IScheduleUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.HD;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToSave = record as HeaderRecord;

            if (recordToSave == null)
                throw new ArgumentException("Failed to cast record for saving");

            _unitOfWork.HeaderRecords.Add(recordToSave);

            _unitOfWork.Complete();

            Trace.TraceInformation("Processed a CIF Header Record.");
        }
    }
}