using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
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

        public async Task Store(IEnumerable<IScheduleRecord> recordsToStore)
        {
            if (recordsToStore == null)
                throw new ArgumentNullException(nameof(recordsToStore));

            await Task.WhenAll(recordsToStore.Select(StoreRecord));
        }

        public async Task Store(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            await StoreRecord(record);
        }

        private async Task StoreRecord(IScheduleRecord record)
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

            await scheduleRecordStorageProcessor.StoreRecord(record);
        }
    }
}