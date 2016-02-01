using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class CifScheduleManager : IScheduleManager
    {
        private readonly IScheduleReader _scheduleReader;
        private readonly IScheduleParser _scheduleParser;
        private readonly IScheduleRecordMerger _scheduleRecordMerger;

        public CifScheduleManager(IScheduleReader scheduleReader, IScheduleParser scheduleParser, IScheduleRecordMerger scheduleRecordMerger)
        {
            if (scheduleReader == null)
                throw new ArgumentNullException(nameof(scheduleReader));
            if (scheduleParser == null)
                throw new ArgumentNullException(nameof(scheduleParser));
            if (scheduleRecordMerger == null)
                throw new ArgumentNullException(nameof(scheduleRecordMerger));

            _scheduleReader = scheduleReader;
            _scheduleParser = scheduleParser;
            _scheduleRecordMerger = scheduleRecordMerger;
        }

        public IList<IScheduleRecord> ParseScheduleRecords(string scheduleFilePath)
        {
            if (string.IsNullOrWhiteSpace(scheduleFilePath))
                throw new ArgumentNullException(nameof(scheduleFilePath));

            var recordsToParse = _scheduleReader.ReadSchedule(scheduleFilePath);

            return _scheduleParser.ParseScheduleFile(recordsToParse);
        }

        public IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords)
        {
            if (scheduleRecords == null || !scheduleRecords.Any())
                throw new ArgumentNullException(nameof(scheduleRecords));

            return _scheduleRecordMerger.MergeScheduleRecords(scheduleRecords);
        }
    }
}