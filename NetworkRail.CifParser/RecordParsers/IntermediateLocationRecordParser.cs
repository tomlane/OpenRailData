using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public class IntermediateLocationRecordParser : ICifRecordParser
    {
        private readonly ILocationRecordParserContainer _recordParserContainer;

        public IntermediateLocationRecordParser(ILocationRecordParserContainer recordParserContainer)
        {
            if (recordParserContainer == null)
                throw new ArgumentNullException(nameof(recordParserContainer));

            _recordParserContainer = recordParserContainer;
        }

        public string RecordKey { get; } = "LI";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new IntermediateLocationRecord
            {
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                WorkingArrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(10, 5)),
                WorkingDeparture = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(15, 5)),
                Pass = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(20, 5)),
                PublicArrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(25, 4)),
                PublicDeparture = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(29, 4)),
                Platform = recordString.Substring(33, 3).Trim(),
                Line = recordString.Substring(36, 3).Trim(),
                Path = recordString.Substring(39, 3).Trim(),
                LocationActivityString = recordString.Substring(42, 12),
                EngineeringAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(54, 2)),
                PathingAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(56, 2)),
                PerformanceAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(58, 2))
            };

            record.LocationActivity = _recordParserContainer.LocationActivityParser.ParseActivity(record.LocationActivityString);

            record.OrderTime = record.Pass ?? record.WorkingDeparture;

            return record;
        }
    }
}