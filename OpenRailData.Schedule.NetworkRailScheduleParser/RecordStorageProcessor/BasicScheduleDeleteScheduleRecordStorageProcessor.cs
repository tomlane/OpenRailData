using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class BasicScheduleDeleteScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.BSD;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Trace.TraceInformation("Processed a Basic Schedule Delete Record.");
        }
    }
}