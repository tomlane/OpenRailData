using System;
using Common.Logging;
using OpenRailData.Schedule.DataAccess.Core;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class TiplocAmendScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ILog Logger = LogManager.GetLogger("RecordStorage.Tiploc.Amend");

        public TiplocAmendScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.TA;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.TiplocRecords.AmendRecord(record as TiplocRecord);

                unitOfWork.Complete();
            }

            if (Logger.IsTraceEnabled)
                Logger.Trace("Processed a Tiploc Amend Record.");
        }
    }
}