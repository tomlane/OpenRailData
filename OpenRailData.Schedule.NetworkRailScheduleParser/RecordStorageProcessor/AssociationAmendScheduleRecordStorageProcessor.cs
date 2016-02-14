using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class AssociationAmendScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.AAR;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Trace.TraceInformation("Processed a Association Amend Record.");
        }
    }
}