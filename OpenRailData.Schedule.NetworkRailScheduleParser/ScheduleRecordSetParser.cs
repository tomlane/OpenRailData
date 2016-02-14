using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class ScheduleRecordSetParser : IScheduleRecordSetParser
    {
        private readonly Dictionary<string, IScheduleRecordParser> _cifRecordParsers;

        public ScheduleRecordSetParser(IScheduleRecordParser[] recordParsers)
        {
            if (recordParsers == null)
                throw new ArgumentNullException(nameof(recordParsers));

            _cifRecordParsers = recordParsers.ToDictionary(x => x.RecordKey, x => x);
        }

        public IEnumerable<IScheduleRecord> ParseScheduleRecordSet(IEnumerable<string> recordsToParse)
        {
            if (recordsToParse == null)
                throw new ArgumentNullException(nameof(recordsToParse));

            var resultList = new List<IScheduleRecord>();

            foreach (var record in recordsToParse)
            {
                var recordType = record.Substring(0, 2);

                IScheduleRecordParser parser;

                try
                {
                    parser = _cifRecordParsers[recordType];
                }
                catch (KeyNotFoundException exception)
                {
                    throw new ArgumentException($"No parser found for record type {recordType}", exception);
                }

                resultList.Add(parser.ParseRecord(record));
            }

            Trace.TraceInformation("Finished parsing schedule records.");

            return resultList;
        }
    }
}