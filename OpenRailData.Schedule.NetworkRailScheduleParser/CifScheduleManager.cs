using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class CifScheduleManager : IScheduleManager
    {
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
            Console.WriteLine("GetRecordsByScheduleFileUrl called.");

            var scheduleFile = _scheduleFileFetcher.FetchScheduleFileFromUrl(url);

            var recordsToParse = _scheduleFileRecordExtractor.ExtractScheduleFileRecords(scheduleFile);

            return _scheduleRecordSetParser.ParseScheduleRecordSet(recordsToParse).ToList();
        }

        public IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords)
        {
            if (scheduleRecords == null || !scheduleRecords.Any())
                throw new ArgumentNullException(nameof(scheduleRecords));

            Console.WriteLine("MergeScheduleRecords called.");
            
            return _scheduleRecordMerger.MergeScheduleRecords(scheduleRecords);
        }

        public void SaveScheduleRecords(IList<IScheduleRecord> scheduleRecordsToSave)
        {
            if (scheduleRecordsToSave == null || !scheduleRecordsToSave.Any())
                throw new ArgumentNullException(nameof(scheduleRecordsToSave));

            _scheduleRecordStorer.StoreScheduleRecords(scheduleRecordsToSave);
        }
    }
}