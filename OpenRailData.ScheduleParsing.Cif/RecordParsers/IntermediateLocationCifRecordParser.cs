using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;

namespace OpenRailData.ScheduleParsing.Cif.RecordParsers
{
    public class IntermediateLocationCifRecordParser : IScheduleRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers; 
        private readonly ITimingAllowanceParser _timingAllowanceParser;

        public IntermediateLocationCifRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers, ITimingAllowanceParser timingAllowanceParser)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));
            if (timingAllowanceParser == null)
                throw new ArgumentNullException(nameof(timingAllowanceParser));

            _timingAllowanceParser = timingAllowanceParser;
            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
        }

        /// <summary>
        /// The schedule record key for this parser.
        /// </summary>
        public string RecordKey { get; } = "LI";

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
                RecordIdentity = ScheduleRecordType.LI,
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                WorkingArrival = ScheduleLocationTimeParser.ParseLocationTimeString(recordString.Substring(10, 5).Trim()),
                WorkingDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(recordString.Substring(15, 5).Trim()),
                Pass = ScheduleLocationTimeParser.ParseLocationTimeString(recordString.Substring(20, 5).Trim()),
                PublicArrival = ScheduleLocationTimeParser.ParseLocationTimeString(recordString.Substring(25, 4).Trim()),
                PublicDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(recordString.Substring(29, 4).Trim()),
                Platform = recordString.Substring(33, 3).Trim(),
                Line = recordString.Substring(36, 3).Trim(),
                Path = recordString.Substring(39, 3).Trim(),
                LocationActivityString = recordString.Substring(42, 12),
                EngineeringAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(54, 2)),
                PathingAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(56, 2)),
                PerformanceAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(58, 2))
            };

            record.LocationActivity = (LocationActivity)_enumPropertyParsers["LocationActivity"].ParseProperty(record.LocationActivityString);

            if (record.PublicArrival == LocalTime.Midnight)
                record.PublicArrival = null;

            if (record.PublicDeparture == LocalTime.Midnight)
                record.PublicDeparture = null;

            record.OrderTime = record.Pass ?? record.WorkingDeparture;
            
            return record;
        }
    }
}