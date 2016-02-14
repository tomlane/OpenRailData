using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class TiplocInsertScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IDbContextFactory<ScheduleContext> _contextFactory;

        public TiplocInsertScheduleRecordStorageProcessor(IDbContextFactory<ScheduleContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.TI;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToSave = record as TiplocRecord;

            if (recordToSave == null)
                throw new ArgumentException("Failed to cast entity for saving.");

            using (var unitOfWork = new ScheduleUnitOfWork(_contextFactory.Create()))
            {
                unitOfWork.TiplocRecords.Add(recordToSave);

                unitOfWork.Complete();
            }

            Trace.TraceInformation("Processed a Tiploc Insert Record.");
        }
    }
}