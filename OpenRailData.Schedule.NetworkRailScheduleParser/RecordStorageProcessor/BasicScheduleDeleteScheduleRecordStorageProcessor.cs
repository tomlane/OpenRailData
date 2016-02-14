using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class BasicScheduleDeleteScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IDbContextFactory<ScheduleContext> _contextFactory;

        public BasicScheduleDeleteScheduleRecordStorageProcessor(IDbContextFactory<ScheduleContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.BSD;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            
            using (var unitOfWork = new ScheduleUnitOfWork(_contextFactory.Create()))
            {
                unitOfWork.ScheduleRecords.DeleteRecord(record as ScheduleRecord);

                unitOfWork.Complete();
            }

            Trace.TraceInformation("Processed a Basic Schedule Delete Record.");
        }
    }
}