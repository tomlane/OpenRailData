using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;

namespace OpenRailData.ScheduleParsing.Cif.RecordParsers
{
    public class TerminatingLocationCifRecordParser : IScheduleRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers; 

        public TerminatingLocationCifRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));

            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
        }

        /// <summary>
        /// The schedule record key for this parser.
        /// </summary>
        public string RecordKey { get; } = "LT";

        /// <summary>
        /// Parses a record string in to a schedule record entity.
        /// </summary>
        /// <param name="recordString">The schedule record string.</param>
        /// <returns>A schedule record entity.</returns>
        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new ScheduleLocationRecord
            {
                RecordIdentity = ScheduleRecordType.LT,
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                WorkingArrival = recordString.Substring(10, 5).Trim(),
                PublicArrival = recordString.Substring(15, 4).Trim(),
                Platform = recordString.Substring(19, 3).Trim(),
                Path = recordString.Substring(22, 3).Trim(),
                LocationActivityString = recordString.Substring(25, 12),
            };

            record.LocationActivity = (LocationActivity)_enumPropertyParsers["LocationActivity"].ParseProperty(record.LocationActivityString);

            record.OrderTime = record.WorkingArrival;

            if (record.PublicArrival == "0000")
                record.PublicArrival = string.Empty;

            if (record.PublicDeparture == "0000")
                record.PublicDeparture = string.Empty;

            return record;
        }
    }
}