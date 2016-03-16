using System;
using Common.Logging;
using OpenRailData.Schedule.DataAccess.Core;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class AssociationAmendScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ILog Logger = LogManager.GetLogger("RecordStorage.Association.Amend");

        public AssociationAmendScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.AAR;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.AssociationRecords.AmendRecord(record as AssociationRecord);

                unitOfWork.Complete();
            }

            if (Logger.IsTraceEnabled)
                Logger.Trace("Processed an Association Amend Record.");
        }
    }
}