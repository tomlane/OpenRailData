using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class TiplocInsertScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWork _unitOfWork;

        public TiplocInsertScheduleRecordStorageProcessor(IScheduleUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.TI;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToSave = record as TiplocRecord;

            if (recordToSave == null)
                throw new ArgumentException("Failed to cast entity for saving.");

            _unitOfWork.TiplocRecords.Add(recordToSave);

            _unitOfWork.Complete();

            Trace.TraceInformation("Processed a Tiploc Insert Record.");
        }
    }
}