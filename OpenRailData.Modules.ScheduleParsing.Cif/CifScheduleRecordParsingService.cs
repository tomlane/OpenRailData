using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif
{
    public class CifScheduleRecordParsingService : IScheduleRecordParsingService
    {
        private readonly Dictionary<string, IScheduleRecordParser> _cifRecordParsers;

        public CifScheduleRecordParsingService(IScheduleRecordParser[] recordParsers)
        {
            if (recordParsers == null)
                throw new ArgumentNullException(nameof(recordParsers));

            _cifRecordParsers = recordParsers.ToDictionary(x => x.RecordKey, x => x);
        }

        public IEnumerable<IScheduleRecord> ParseScheduleRecords(IEnumerable<string> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));
            
            var parsedRecords = new List<IScheduleRecord>();
                
            records.ToList().ForEach(r => parsedRecords.Add(ParseRecord(r)));

            return parsedRecords;
        }

        private IScheduleRecord ParseRecord(string record)
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

            return parser.ParseRecord(record);
        }
    }
}