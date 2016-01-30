using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.CifRecordParsers
{
    public class ChangesEnRouteRecordParser : ICifRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers;

        public ChangesEnRouteRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));

            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
        }

        public string RecordKey { get; } = "CR";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new ChangesEnRouteRecord
            {
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                Category = recordString.Substring(10, 2).Trim(),
                TrainIdentity = recordString.Substring(12, 4).Trim(),
                HeadCode = recordString.Substring(16, 4).Trim(),
                CourseIndicator = recordString.Substring(20, 1).Trim(),
                ServiceCode = recordString.Substring(21, 8).Trim(),
                PortionId = recordString.Substring(29, 1).Trim(),
                PowerType = (PowerType)_enumPropertyParsers["PowerType"].ParseProperty(recordString.Substring(30, 3).Trim()),
                TimingLoad = recordString.Substring(33, 4).Trim(),
                OperatingCharacteristics = recordString.Substring(40, 6).Trim(),
                SeatingClass = (SeatingClass)_enumPropertyParsers["SeatingClass"].ParseProperty(recordString.Substring(46, 1)),
                Sleepers = (SleeperDetails)_enumPropertyParsers["SleeperDetails"].ParseProperty(recordString.Substring(47, 1)),
                Reservations = (ReservationDetails)_enumPropertyParsers["ReservationDetails"].ParseProperty(recordString.Substring(48, 1)),
                ConnectionIndicator = recordString.Substring(49, 1).Trim(),
                CateringCode = recordString.Substring(50, 4).Trim(),
                ServiceBranding = recordString.Substring(54, 4).Trim(),
                UicCode = recordString.Substring(58, 5).Trim(),
                Rsid = recordString.Substring(63, 8).Trim()
            };

            int speed;
            bool speedParsed = int.TryParse(recordString.Substring(37, 3).Trim(), NumberStyles.Any,
                new CultureInfo("en-gb"), out speed);

            if (speedParsed)
                record.Speed = speed;

            return record;
        }
    }
}