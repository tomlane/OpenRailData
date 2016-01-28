﻿using System;
using System.Collections.Generic;
using System.Linq;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordParsers
{
    public class OriginLocationRecordParser : ICifRecordParser
    {
        private readonly ITimingAllowanceParser _timingAllowanceParser;
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers; 

        public OriginLocationRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers, ITimingAllowanceParser timingAllowanceParser)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));
            if (timingAllowanceParser == null)
                throw new ArgumentNullException(nameof(timingAllowanceParser));

            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
            _timingAllowanceParser = timingAllowanceParser;
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
                WorkingDeparture = recordString.Substring(10, 5).Trim(),
                PublicDeparture = recordString.Substring(15, 4).Trim(),
                Platform = recordString.Substring(19, 3).Trim(),
                Line = recordString.Substring(22, 3).Trim(),
                EngineeringAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(25, 2)),
                PathingAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(27, 2)),
                LocationActivityString = recordString.Substring(29, 12),
                PerformanceAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(41, 2))
            };

            record.LocationActivity = (LocationActivity)_enumPropertyParsers["LocationActivity"].ParseProperty(record.LocationActivityString);

            record.OrderTime = record.WorkingDeparture;

            return record;
        }
    }
}