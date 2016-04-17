using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Logging;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorageService
{
    public class ScheduleRecordStorageService : IScheduleRecordStorageService
    {
        private readonly Dictionary<ScheduleRecordType, IScheduleRecordStorageProcessor> _storageProcessors;
        private readonly ILog Logger = LogManager.GetLogger("Schedule.ScheduleRecordStorageService");


        public ScheduleRecordStorageService(IScheduleRecordStorageProcessor[] scheduleRecordStorageProcessors)
        {
            if (scheduleRecordStorageProcessors == null)
                throw new ArgumentNullException(nameof(scheduleRecordStorageProcessors));

            _storageProcessors = scheduleRecordStorageProcessors.ToDictionary(x => x.RecordKey, x => x);
        }

        public void StoreScheduleRecords(IEnumerable<IScheduleRecord> recordsToStore)
        {
            if (Logger.IsInfoEnabled)
                Logger.Info("Starting to store schedule records.");

            if (recordsToStore == null)
                throw new ArgumentNullException(nameof(recordsToStore));

            Parallel.ForEach(recordsToStore, StoreRecord);
            
            if (Logger.IsInfoEnabled)
                Logger.Info("Finished storing schedule records.");
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