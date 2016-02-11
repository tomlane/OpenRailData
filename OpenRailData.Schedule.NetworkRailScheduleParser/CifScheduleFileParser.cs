using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class CifScheduleFileParser : IScheduleFileParser
    {
        private readonly Dictionary<string, IScheduleRecordParser> _cifRecordParsers;

        public CifScheduleFileParser(IScheduleRecordParser[] recordParsers)
        {
            if (recordParsers == null)
                throw new ArgumentNullException(nameof(recordParsers));

            _cifRecordParsers = recordParsers.ToDictionary(x => x.RecordKey, x => x);
        }

        public IList<IScheduleRecord> ParseScheduleFile(byte[] scheduleFile)
        {
            if (scheduleFile == null) 
                throw new ArgumentNullException(nameof(scheduleFile));

            var recordsToParse = new List<string>();
            var resultList = new List<IScheduleRecord>();

            using (var streamReader = new StreamReader(new MemoryStream(scheduleFile)))
            {
                string record;
                while ((record = streamReader.ReadLine()) != null)
                {
                    recordsToParse.Add(record);
                }
            }

            Trace.TraceInformation("Starting to parse schedule records...");

            foreach (var record in recordsToParse)
            {
                string recordType = record.Substring(0, 2);

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