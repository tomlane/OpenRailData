﻿using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;

namespace OpenRailData.ScheduleParsing.Cif.RecordParsers
{
    public class OriginLocationCifRecordParser : IScheduleRecordParser
    {
        private readonly ITimingAllowanceParser _timingAllowanceParser;
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers; 

        public OriginLocationCifRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers, ITimingAllowanceParser timingAllowanceParser)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));
            if (timingAllowanceParser == null)
                throw new ArgumentNullException(nameof(timingAllowanceParser));

            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
            _timingAllowanceParser = timingAllowanceParser;
        }

        /// <summary>
        /// The schedule record key for this parser.
        /// </summary>
        public string RecordKey { get; } = "LO";

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
                RecordIdentity = ScheduleRecordType.LO,
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                WorkingDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(recordString.Substring(10, 5).Trim()),
                PublicDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(recordString.Substring(15, 4).Trim()),
                Platform = recordString.Substring(19, 3).Trim(),
                Line = recordString.Substring(22, 3).Trim(),
                EngineeringAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(25, 2)),
                PathingAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(27, 2)),
                LocationActivityString = recordString.Substring(29, 12),
                PerformanceAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(41, 2))
            };

            record.LocationActivity = (LocationActivity)_enumPropertyParsers["LocationActivity"].ParseProperty(record.LocationActivityString);

            if (record.PublicArrival == LocalTime.Midnight)
                record.PublicArrival = null;

            if (record.PublicDeparture == LocalTime.Midnight)
                record.PublicDeparture = null;

            record.OrderTime = record.WorkingDeparture;
            
            return record;
        }
    }
}