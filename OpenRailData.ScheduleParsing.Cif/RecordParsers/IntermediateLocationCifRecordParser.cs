using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;

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
                WorkingArrival = recordString.Substring(10, 5).Trim(),
                WorkingDeparture = recordString.Substring(15, 5).Trim(),
                Pass = recordString.Substring(20, 5).Trim(),
                PublicArrival = recordString.Substring(25, 4).Trim(),
                PublicDeparture = recordString.Substring(29, 4).Trim(),
                Platform = recordString.Substring(33, 3).Trim(),
                Line = recordString.Substring(36, 3).Trim(),
                Path = recordString.Substring(39, 3).Trim(),
                LocationActivityString = recordString.Substring(42, 12),
                EngineeringAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(54, 2)),
                PathingAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(56, 2)),
                PerformanceAllowance = _timingAllowanceParser.ParseTime(recordString.Substring(58, 2))
            };

            record.LocationActivity = (LocationActivity)_enumPropertyParsers["LocationActivity"].ParseProperty(record.LocationActivityString);

            record.OrderTime = !string.IsNullOrWhiteSpace(record.Pass) ? record.Pass : record.WorkingDeparture;

            if (record.PublicArrival == "0000")
                record.PublicArrival = string.Empty;

            if (record.PublicDeparture == "0000")
                record.PublicDeparture = string.Empty;
            
            return record;
        }
    }
}