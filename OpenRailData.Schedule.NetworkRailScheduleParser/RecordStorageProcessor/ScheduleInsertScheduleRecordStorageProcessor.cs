using System;
using Common.Logging;
using OpenRailData.Schedule.DataAccess.Core;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class ScheduleInsertScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ILog Logger = LogManager.GetLogger("RecordStorage.Schedule.Insert");


        public ScheduleInsertScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.BSN;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.ScheduleRecords.InsertRecord(record as ScheduleRecord);

                unitOfWork.Complete();
            }

            if (Logger.IsTraceEnabled)
                Logger.Trace("Processed a Schedule Insert Record.");
        }
    }
}