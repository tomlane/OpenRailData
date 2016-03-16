using System;
using Common.Logging;
using OpenRailData.Schedule.DataAccess.Core;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class TiplocInsertScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ILog Logger = LogManager.GetLogger("RecordStorage.Tiploc.Insert");
        
        public TiplocInsertScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.TI;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.TiplocRecords.InsertRecord(record as TiplocRecord);

                unitOfWork.Complete();
            }

            if (Logger.IsTraceEnabled)
                Logger.Trace("Processed a Tiploc Insert Record.");
        }
    }
}