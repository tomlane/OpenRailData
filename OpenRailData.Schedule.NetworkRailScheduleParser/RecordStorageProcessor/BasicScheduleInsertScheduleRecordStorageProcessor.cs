using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class BasicScheduleInsertScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWork _unitOfWork;

        public BasicScheduleInsertScheduleRecordStorageProcessor(IScheduleUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.BSN;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToSave = record as ScheduleRecord;

            _unitOfWork.ScheduleRecords.Add(recordToSave);

            _unitOfWork.Complete();

            Trace.TraceInformation("Processed a Basic Schedule Insert Record.");
        }
    }
}