using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class CifScheduleManager : IScheduleManager
    {
        private readonly IScheduleFileFetcher _scheduleFileFetcher;
        private readonly IScheduleFileParser _scheduleFileParser;
        private readonly IScheduleRecordMerger _scheduleRecordMerger;

        public CifScheduleManager(IScheduleFileFetcher scheduleFileFetcher, IScheduleFileParser scheduleFileParser, IScheduleRecordMerger scheduleRecordMerger)
        {
            if (scheduleFileFetcher == null)
                throw new ArgumentNullException(nameof(scheduleFileFetcher));
            if (scheduleFileParser == null)
                throw new ArgumentNullException(nameof(scheduleFileParser));
            if (scheduleRecordMerger == null)
                throw new ArgumentNullException(nameof(scheduleRecordMerger));

            _scheduleFileFetcher = scheduleFileFetcher;
            _scheduleFileParser = scheduleFileParser;
            _scheduleRecordMerger = scheduleRecordMerger;
        }

        public IList<IScheduleRecord> GetDailyUpdateScheduleRecords()
        {
            Trace.TraceInformation("GetDailyUpdateScheduleRecords called.");

            return _scheduleFileParser.ParseScheduleFile(_scheduleFileFetcher.FetchDailyScheduleUpdateFile());
        }

        public IList<IScheduleRecord> GetWeeklyScheduleRecords()
        {
            Trace.TraceInformation("GetWeeklyScheduleRecords called.");

            return _scheduleFileParser.ParseScheduleFile(_scheduleFileFetcher.FetchWeeklyScheduleFile());
        }

        public IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords)
        {
            if (scheduleRecords == null || !scheduleRecords.Any())
                throw new ArgumentNullException(nameof(scheduleRecords));

            Trace.TraceInformation("MergeScheduleRecords called.");
            
            return _scheduleRecordMerger.MergeScheduleRecords(scheduleRecords);
        }
    }
}