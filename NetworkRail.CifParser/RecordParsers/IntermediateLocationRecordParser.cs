﻿using System;
using System.Collections.Generic;
using System.Linq;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordParsers
{
    public class IntermediateLocationRecordParser : ICifRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers; 
        private readonly ITimingAllowanceParser _timingAllowanceParser;

        public IntermediateLocationRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers, ITimingAllowanceParser timingAllowanceParser)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));
            if (timingAllowanceParser == null)
                throw new ArgumentNullException(nameof(timingAllowanceParser));

            _timingAllowanceParser = timingAllowanceParser;
            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
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
                WorkingArrival = recordString.Substring(10, 5),
                WorkingDeparture = recordString.Substring(15, 5),
                Pass = recordString.Substring(20, 5),
                PublicArrival = recordString.Substring(25, 4),
                PublicDeparture = recordString.Substring(29, 4),
                Platform = recordString.Substring(33, 3).Trim(),
                Line = recordString.Substring(36, 3).Trim(),
                Path = recordString.Substring(39, 3).Trim(),
                LocationActivityString = recordString.Substring(42, 12),
                EngineeringAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(54, 2)),
                PathingAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(56, 2)),
                PerformanceAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(58, 2))
            };

            record.LocationActivity = (LocationActivity)_enumPropertyParsers["LocationActivity"].ParseProperty(record.LocationActivityString);

            record.OrderTime = record.Pass ?? record.WorkingDeparture;

            return record;
        }
    }
}