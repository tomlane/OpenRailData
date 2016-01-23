using System;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public class TerminatingLocationRecordParser : ICifRecordParser
    {
        private readonly ILocationRecordParserContainer _recordParserContainer;

        public TerminatingLocationRecordParser(ILocationRecordParserContainer recordParserContainer)
        {
            if (recordParserContainer == null)
                throw new ArgumentNullException(nameof(recordParserContainer));

            _recordParserContainer = recordParserContainer;
        }

        public string RecordKey { get; } = "LT";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new TerminatingLocationRecord
            {
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                WorkingArrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(10, 5)),
                PublicArrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(15, 4)),
                Platform = recordString.Substring(19, 3).Trim(),
                Path = recordString.Substring(22, 3).Trim(),
                LocationActivityString = recordString.Substring(25, 12),
            };

            record.LocationActivity = _recordParserContainer.LocationActivityParser.ParseActivity(record.LocationActivityString);

            record.OrderTime = record.WorkingArrival;

            return record;
        }
    }
}