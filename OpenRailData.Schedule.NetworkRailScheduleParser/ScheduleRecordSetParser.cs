using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class ScheduleRecordSetParser : IScheduleRecordSetParser
    {
        private readonly IHeaderRecordValidator _headerRecordValidator;
        private readonly Dictionary<string, IScheduleRecordParser> _cifRecordParsers;

        private readonly ILog Logger = LogManager.GetLogger("Schedule.Util.CifRecordSetParser");

        public ScheduleRecordSetParser(IScheduleRecordParser[] recordParsers, IHeaderRecordValidator headerRecordValidator)
        {
            if (recordParsers == null)
                throw new ArgumentNullException(nameof(recordParsers));
            if (headerRecordValidator == null)
                throw new ArgumentNullException(nameof(headerRecordValidator));

            _cifRecordParsers = recordParsers.ToDictionary(x => x.RecordKey, x => x);
            _headerRecordValidator = headerRecordValidator;
        }

        public IEnumerable<IScheduleRecord> ParseScheduleRecordSet(IEnumerable<string> recordsToParse)
        {
            if (Logger.IsInfoEnabled)
                Logger.Info("Starting to parse Schedule record set.");

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

                var result = parser.ParseRecord(record);

                if (result.RecordIdentity == ScheduleRecordType.HD)
                    _headerRecordValidator.ValidateHeaderRecord(new HeaderRecordValidationRequest
                    {
                        RecordToCheck = result as HeaderRecord
                    });

                resultList.Add(result);
            }

            if (Logger.IsInfoEnabled)
                Logger.Info("Finished parsing schedule record set.");

            return resultList;
        }
    }
}