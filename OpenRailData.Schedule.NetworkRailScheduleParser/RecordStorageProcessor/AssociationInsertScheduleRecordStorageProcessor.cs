using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class AssociationInsertScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IDbContextFactory<ScheduleContext> _contextFactory;

        public AssociationInsertScheduleRecordStorageProcessor(IDbContextFactory<ScheduleContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.AAN;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToSave = record as AssociationRecord;

            if (recordToSave == null)
                throw new ArgumentException("Failed to cast record for saving.");

            using (var unitOfWork = new ScheduleUnitOfWork(_contextFactory.Create()))
            {
                unitOfWork.AssociationRecords.Add(recordToSave);

                unitOfWork.Complete();
            }

            Trace.TraceInformation("Processed a Association Insert Record.");
        }
    }
}