using System;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class LocationRecordBuilder : ICifRecordBuilder<LocationRecord>
    {
        private readonly ILocationActivityParser _locationActivityParser;

        public LocationRecordBuilder(ILocationActivityParser locationActivityParser)
        {
            if (locationActivityParser == null)
                throw new ArgumentNullException(nameof(locationActivityParser));

            _locationActivityParser = locationActivityParser;
        }

        public LocationRecord BuildRecord(string recordString)
        {
            LocationRecord record = new LocationRecord
            {
                RecordType = recordString.Substring(0, 2),
                Tiploc = recordString.Substring(2, 7),
                TiplocInstance = recordString.Substring(9, 1)
            };


            if (record.RecordType == "LO")
            {
                record.Departure = recordString.Substring(10, 5);
                record.PublicDeparture = recordString.Substring(15, 4);
                record.Platform = recordString.Substring(19, 3);
                record.Line = recordString.Substring(22, 3);
                record.EngineeringAllowance = recordString.Substring(25, 2);
                record.PathingAllowance = recordString.Substring(27, 2);
                record.ActivityString = recordString.Substring(29, 12);
                record.PerformanceAllowance = recordString.Substring(41, 2);
            }
            else if (record.RecordType == "LI")
            {
                record.Arrival = recordString.Substring(10, 5);
                record.Departure = recordString.Substring(15, 5);
                record.Pass = recordString.Substring(20, 5);
                record.PublicArrival = recordString.Substring(25, 4);
                record.PublicDeparture = recordString.Substring(29, 4);
                record.Platform = recordString.Substring(33, 3);
                record.Line = recordString.Substring(36, 3);
                record.Path = recordString.Substring(39, 3);
                record.ActivityString = recordString.Substring(42, 12);
                record.EngineeringAllowance = recordString.Substring(54, 2);
                record.PathingAllowance = recordString.Substring(56, 2);
                record.PerformanceAllowance = recordString.Substring(58, 2);
            }
            else if (record.RecordType == "LT")
            {
                record.Arrival = recordString.Substring(10, 5);
                record.PublicArrival = recordString.Substring(15, 4);
                record.Platform = recordString.Substring(19, 3);
                record.Path = recordString.Substring(22, 3);
                record.ActivityString = recordString.Substring(25, 12);
            }

            record.Tiploc = record.Tiploc.Trim();
            record.TiplocInstance = record.TiplocInstance.Trim();

            record.Arrival = record.Arrival.Trim();
            record.Departure = record.Departure.Trim();
            record.Pass = record.Pass.Trim();
            record.PublicArrival = record.PublicArrival.Trim();
            record.PublicDeparture = record.PublicDeparture.Trim();

            record.Platform = record.Platform.Trim();
            record.Line = record.Line.Trim();
            record.Path = record.Path.Trim();
            record.EngineeringAllowance = record.EngineeringAllowance.Trim();
            record.PathingAllowance = record.PathingAllowance.Trim();
            record.PerformanceAllowance = record.PerformanceAllowance.Trim();

            if (record.PublicArrival == "0000")
                record.PublicArrival = string.Empty;

            if (record.PublicDeparture == "0000")
                record.PublicDeparture = string.Empty;

            record.Activity = _locationActivityParser.ParseActivity(record.ActivityString);
            record.ActivityString = record.ActivityString.Trim();

            record.PublicCall = record.Activity.N && (record.PublicArrival != string.Empty || record.PublicDeparture != string.Empty);
            record.ActualCall = record.Arrival != string.Empty || record.Departure != string.Empty;

            if (record.Pass != string.Empty)
                record.OrderTime = record.Pass;
            else if (record.Departure != string.Empty)
                record.OrderTime = record.Departure;
            else
                record.OrderTime = record.Arrival;

            return record;
        }
    }
}