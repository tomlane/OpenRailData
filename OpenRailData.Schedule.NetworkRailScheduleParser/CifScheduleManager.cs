using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class CifScheduleManager : IScheduleManager
    {
        private readonly ILog Logger = LogManager.GetLogger("Schedule.CifScheduleManager");
        
        private readonly IScheduleFileFetcher _scheduleFileFetcher;
        private readonly IScheduleFileRecordExtractor _scheduleFileRecordExtractor;
        private readonly IScheduleRecordMerger _scheduleRecordMerger;
        private readonly IScheduleRecordStorer _scheduleRecordStorer;
        private readonly IScheduleRecordSetParser _scheduleRecordSetParser;

        public CifScheduleManager(IScheduleFileFetcher scheduleFileFetcher, IScheduleFileRecordExtractor scheduleFileRecordExtractor, IScheduleRecordMerger scheduleRecordMerger, IScheduleRecordStorer scheduleRecordStorer, IScheduleRecordSetParser scheduleRecordSetParser)
        {
            if (scheduleFileFetcher == null)
                throw new ArgumentNullException(nameof(scheduleFileFetcher));
            if (scheduleFileRecordExtractor == null)
                throw new ArgumentNullException(nameof(scheduleFileRecordExtractor));
            if (scheduleRecordMerger == null)
                throw new ArgumentNullException(nameof(scheduleRecordMerger));
            if (scheduleRecordStorer == null)
                throw new ArgumentNullException(nameof(scheduleRecordStorer));
            if (scheduleRecordSetParser == null)
                throw new ArgumentNullException(nameof(scheduleRecordSetParser));

            _scheduleFileFetcher = scheduleFileFetcher;
            _scheduleFileRecordExtractor = scheduleFileRecordExtractor;
            _scheduleRecordMerger = scheduleRecordMerger;
            _scheduleRecordStorer = scheduleRecordStorer;
            _scheduleRecordSetParser = scheduleRecordSetParser;
        }

        public IList<IScheduleRecord> GetRecordsByScheduleFileUrl(string url)
        {
            var scheduleFile = _scheduleFileFetcher.FetchScheduleFileFromUrl(url);

            var recordsToParse = _scheduleFileRecordExtractor.ExtractScheduleFileRecords(scheduleFile);

            var result = _scheduleRecordSetParser.ParseScheduleRecordSet(recordsToParse).ToList();

            if (Logger.IsInfoEnabled)
            {
                Logger.Info($"Records Parsed: {result.Count}");
                Logger.Info("Schedule record fetching complete. Ready for parsing.");
            }

            return result;
        }

        public IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords)
        {
            if (scheduleRecords == null || !scheduleRecords.Any())
                throw new ArgumentNullException(nameof(scheduleRecords));

            var result = _scheduleRecordMerger.MergeScheduleRecords(scheduleRecords);
            
            if (Logger.IsInfoEnabled)
                Logger.Info($"Merged Records Count: {result.Count}");
                Logger.Info("Schedule record parsing complete. Ready for storage.");

            return result;
        }

        public void SaveScheduleRecords(IList<IScheduleRecord> scheduleRecordsToSave)
        {
            if (scheduleRecordsToSave == null || !scheduleRecordsToSave.Any())
                throw new ArgumentNullException(nameof(scheduleRecordsToSave));

            _scheduleRecordStorer.StoreScheduleRecords(scheduleRecordsToSave);

            if (Logger.IsInfoEnabled)
                Logger.Info("Schedule storage operation complete.");
        }
    }
}