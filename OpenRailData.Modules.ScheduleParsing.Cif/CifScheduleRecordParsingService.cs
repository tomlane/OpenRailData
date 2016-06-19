using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif
{
    public class CifScheduleRecordParsingService : IScheduleRecordParsingService
    {
        private readonly Dictionary<string, IScheduleRecordParser> _cifRecordParsers;

        private readonly ConcurrentBag<ParsedScheduleRecord> _parsedRecords;

        public CifScheduleRecordParsingService(IScheduleRecordParser[] recordParsers)
        {
            if (recordParsers == null)
                throw new ArgumentNullException(nameof(recordParsers));

            _cifRecordParsers = recordParsers.ToDictionary(x => x.RecordKey, x => x);

            _parsedRecords = new ConcurrentBag<ParsedScheduleRecord>();
        }

        /// <summary>
        /// Parses a set of schedule record strings to schedule entities/objects.
        /// </summary>
        /// <param name="records">The set of  schedule record strings</param>
        /// <returns>A set of record entities.</returns>
        public IEnumerable<IScheduleRecord> ParseScheduleRecords(IEnumerable<string> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var lineSet = BuildLineSet(records);

            Parallel.ForEach(lineSet, ParseRecord);

            return _parsedRecords.OrderBy(x => x.Index).Select(parsedScheduleRecord => parsedScheduleRecord.ScheduleRecord).ToList();
        }

        private void ParseRecord(ScheduleFileLine fileLine)
        {
            var recordType = fileLine.Record.Substring(0, 2);

            IScheduleRecordParser parser;

            try
            {
                parser = _cifRecordParsers[recordType];
            }
            catch (KeyNotFoundException exception)
            {
                throw new ArgumentException($"No parser found for record type {recordType}", exception);
            }

            _parsedRecords.Add(new ParsedScheduleRecord
            {
                Index = fileLine.Index,
                ScheduleRecord = parser.ParseRecord(fileLine.Record)
            });
        }

        private IEnumerable<ScheduleFileLine> BuildLineSet(IEnumerable<string> records)
        {
            var inputRecords = records as string[] ?? records.ToArray();

            return inputRecords.Select((t, i) => new ScheduleFileLine
            {
                Index = i,
                Record = t
            }).ToList();
        }
    }
}