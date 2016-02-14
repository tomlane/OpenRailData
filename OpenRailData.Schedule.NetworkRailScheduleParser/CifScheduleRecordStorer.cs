using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class CifScheduleRecordStorer : IScheduleRecordStorer
    {
        private readonly Dictionary<ScheduleRecordType, IScheduleRecordStorageProcessor> _storageProcessors; 

        public CifScheduleRecordStorer(IScheduleRecordStorageProcessor[] scheduleRecordStorageProcessors)
        {
            if (scheduleRecordStorageProcessors == null)
                throw new ArgumentNullException(nameof(scheduleRecordStorageProcessors));

            _storageProcessors = scheduleRecordStorageProcessors.ToDictionary(x => x.RecordKey, x => x);
        }

        public void StoreScheduleRecords(IList<IScheduleRecord> recordsToStore)
        {
            if (recordsToStore == null || !recordsToStore.Any())
                throw new ArgumentNullException(nameof(recordsToStore));

            Parallel.ForEach(recordsToStore, StoreRecord);

            Trace.TraceInformation("Finished storing schedule records.");
        }

        private void StoreRecord(IScheduleRecord record)
        {
            IScheduleRecordStorageProcessor scheduleRecordStorageProcessor;

            try
            {
                scheduleRecordStorageProcessor = _storageProcessors[record.RecordIdentity];
            }
            catch (KeyNotFoundException exception)
            {
                throw new ArgumentException($"No storage processor found for record type {record.RecordIdentity}", exception);
            }

            scheduleRecordStorageProcessor.StoreRecord(record);
        }
    }
}