using System;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class LocationRecordBuilder : ICifRecordBuilder<LocationRecord>
    {
        private readonly ILocationRecordParserContainer _recordParserContainer;

        public LocationRecordBuilder(ILocationRecordParserContainer recordParserContainer)
        {
            if (recordParserContainer == null)
                throw new ArgumentNullException(nameof(recordParserContainer));

            _recordParserContainer = recordParserContainer;
        }

        public LocationRecord BuildRecord(string recordString)
        {
            LocationRecord record = new LocationRecord
            {
                RecordIdentity = CifRecordType.Location,
                LocationType = _recordParserContainer.LocationTypeParser.ParseLocationType(recordString.Substring(0, 2)),
                Tiploc = recordString.Substring(2, 7),
                TiplocSuffix = recordString.Substring(9, 1)
            };


            if (record.LocationType == LocationType.Originating)
            {
                record.Departure = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(10, 5));
                record.PublicDeparture = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(15, 4));
                record.Platform = recordString.Substring(19, 3).Trim();
                record.Line = recordString.Substring(22, 3).Trim();
                record.EngineeringAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(25, 2));
                record.PathingAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(27, 2));
                record.LocationActivityString = recordString.Substring(29, 12);
                record.PerformanceAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(41, 2));
            }
            else if (record.LocationType == LocationType.Intermediate)
            {
                record.Arrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(10, 5));
                record.Departure = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(15, 5));
                record.Pass = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(20, 5));
                record.PublicArrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(25, 4));
                record.PublicDeparture = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(29, 4));
                record.Platform = recordString.Substring(33, 3).Trim();
                record.Line = recordString.Substring(36, 3).Trim();
                record.Path = recordString.Substring(39, 3).Trim();
                record.LocationActivityString = recordString.Substring(42, 12);
                record.EngineeringAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(54, 2));
                record.PathingAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(56, 2));
                record.PerformanceAllowance = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(58, 2));
            }
            else if (record.LocationType == LocationType.Terminating)
            {
                record.Arrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(10, 5));
                record.PublicArrival = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(15, 4));
                record.Platform = recordString.Substring(19, 3).Trim();
                record.Path = recordString.Substring(22, 3).Trim();
                record.LocationActivityString = recordString.Substring(25, 12);
            }

            record.Tiploc = record.Tiploc.Trim();
            record.TiplocSuffix = record.TiplocSuffix.Trim();
            
            record.LocationActivity = _recordParserContainer.LocationActivityParser.ParseActivity(record.LocationActivityString);

            if (record.Pass != null)
                record.OrderTime = record.Pass;
            else if (record.Departure != null)
                record.OrderTime = record.Departure;
            else
                record.OrderTime = record.Arrival;

            return record;
        }
    }
}