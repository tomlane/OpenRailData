using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorageService
{
    public class ScheduleRecordStorageService : IScheduleRecordStorageService
    {
        private readonly Dictionary<ScheduleRecordType, IScheduleRecordStorageProcessor> _storageProcessors;
        
        public ScheduleRecordStorageService(IScheduleRecordStorageProcessor[] scheduleRecordStorageProcessors)
        {
            if (scheduleRecordStorageProcessors == null)
                throw new ArgumentNullException(nameof(scheduleRecordStorageProcessors));

            _storageProcessors = scheduleRecordStorageProcessors.ToDictionary(x => x.RecordKey, x => x);
        }

        public void Store(IEnumerable<IScheduleRecord> recordsToStore)
        {
            if (recordsToStore == null)
                throw new ArgumentNullException(nameof(recordsToStore));

            Parallel.ForEach(recordsToStore, StoreRecord);
        }

        public void Store(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            StoreRecord(record);
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