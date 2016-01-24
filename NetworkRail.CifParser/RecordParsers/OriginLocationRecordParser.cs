using System;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public class OriginLocationRecordParser : ICifRecordParser
    {
        private readonly ILocationRecordParserContainer _recordParserContainer;

        public OriginLocationRecordParser(ILocationRecordParserContainer recordParserContainer)
        {
            if (recordParserContainer == null)
                throw new ArgumentNullException(nameof(recordParserContainer));

            _recordParserContainer = recordParserContainer;
        }

        public string RecordKey { get; } = "LO";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new OriginLocationRecord
            {
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                WorkingDeparture = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(10, 5)),
                PublicDeparture = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(15, 4)),
                Platform = recordString.Substring(19, 3).Trim(),
                Line = recordString.Substring(22, 3).Trim(),
                EngineeringAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(25, 2)),
                PathingAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(27, 2)),
                LocationActivityString = recordString.Substring(29, 12),
                PerformanceAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(41, 2))
            };

            record.LocationActivity = _recordParserContainer.LocationActivityParser.ParseActivity(record.LocationActivityString);

            record.OrderTime = record.WorkingDeparture;

            return record;
        }
    }
}