using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OpenRailData.Domain.ScheduleRecords;
using Serilog;

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

        public IEnumerable<IScheduleRecord> ParseScheduleRecords(IEnumerable<string> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var response = new List<IScheduleRecord>();

            foreach (var record in records)
            {
                try
                {
                    var jObject = JObject.Parse(record);

                    var key = jObject.Properties().Select(p => p.Name).ToList().First();

                    response.Add(_recordParsers[key].ParseRecord(record));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occured while trying to parse the following schedule record: {record}", record);
                }
            }

            return response;
        }
    }
}