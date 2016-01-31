using System;
using System.Collections.Generic;
using System.Linq;
using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifScheduleParser : IScheduleParser
    {
        private readonly Dictionary<string, ICifRecordParser> _cifRecordParsers;

        public CifScheduleParser(ICifRecordParser[] recordParsers)
        {
            if (recordParsers == null)
                throw new ArgumentNullException(nameof(recordParsers));

            _cifRecordParsers = recordParsers.ToDictionary(x => x.RecordKey, x => x);
        }

        public IList<IScheduleRecord> ParseScheduleFile(IEnumerable<string> recordsToParse)
        {
            if (recordsToParse == null) 
                throw new ArgumentNullException(nameof(recordsToParse));

            var resultList = new List<IScheduleRecord>();

            foreach (var record in recordsToParse)
            {
                string recordType = record.Substring(0, 2);

                // TODO: Implement end of file record parser
                if (recordType == "ZZ")
                {
                    resultList.Add(new EndOfFileRecord());
                    break;
                }

                ICifRecordParser parser;

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

            return resultList;
        }
    }
}