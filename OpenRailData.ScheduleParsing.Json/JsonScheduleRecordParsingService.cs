using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleParsing;

namespace OpenRailData.ScheduleParsing.Json
{
    public class JsonScheduleRecordParsingService : IScheduleRecordParsingService
    {
        private readonly Dictionary<string, IScheduleRecordParser> _recordParsers;

        public JsonScheduleRecordParsingService(IScheduleRecordParser[] scheduleRecordParsers)
        {
            if (scheduleRecordParsers == null)
                throw new ArgumentNullException(nameof(scheduleRecordParsers));

            _recordParsers = scheduleRecordParsers.ToDictionary(x => x.RecordKey, x => x);
        }

        public IScheduleRecord Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(record));

            return ParseRecord(record);
        }

        public IEnumerable<IScheduleRecord> Parse(IEnumerable<string> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            return records.Select(ParseRecord).Where(x => x.RecordIdentity != 0).ToList();
        }

        private IScheduleRecord ParseRecord(string record)
        {
            var jObject = JObject.Parse(record);

            var key = jObject.Properties().Select(p => p.Name).ToList().First();

            if (key == "EOF")
                return new EndOfFileRecord();

            return _recordParsers[key].ParseRecord(record);
        }
    }
}