using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class BasicScheduleAmendRecordStorageProcessor : IRecordStorageProcessor
    {
        public void StoreRecord(IScheduleRecord recordToStore)
        {
            if (recordToStore == null)
                throw new ArgumentNullException(nameof(recordToStore));

            Trace.TraceInformation("Processed a Basic Schedule Amend Record.");
        }
    }
}