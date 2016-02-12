using System;
using System.Diagnostics;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class BasicScheduleDeleteRecordStorageProcessor : IRecordStorageProcessor
    {
        public void StoreRecord(IScheduleRecord recordToStore)
        {
            if (recordToStore == null)
                throw new ArgumentNullException(nameof(recordToStore));

            Trace.TraceInformation("Processed a Basic Schedule Delete Record.");
        }
    }
}