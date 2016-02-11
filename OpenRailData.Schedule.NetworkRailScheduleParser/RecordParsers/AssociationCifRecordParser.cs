using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers
{
    public class AssociationCifRecordParser : IScheduleRecordParser
    {
        private readonly IDateTimeParser _dateTimeParser;
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers; 

        public AssociationCifRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers, IDateTimeParser dateTimeParser)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));
            if (dateTimeParser == null)
                throw new ArgumentNullException(nameof(dateTimeParser));

            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
            _dateTimeParser = dateTimeParser;
        }

        public string RecordKey { get; } = "AA";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            AssociationRecord record = new AssociationRecord
            {
                TransactionType = (TransactionType)_enumPropertyParsers["TransactionType"].ParseProperty(recordString.Substring(2, 1)),
                MainTrainUid = recordString.Substring(3, 6),
                AssocTrainUid = recordString.Substring(9, 6),
                DateTo = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
                {
                    DateTimeFormat = "yyMMdd",
                    DateTimeString = recordString.Substring(21, 6)
                }),
                AssocDays = (Days)_enumPropertyParsers["RunningDays"].ParseProperty(recordString.Substring(27, 7)),
                Category = (AssociationCategory)_enumPropertyParsers["AssociationCategory"].ParseProperty(recordString.Substring(34, 2)),
                DateIndicator = (DateIndicator)_enumPropertyParsers["DateIndicator"].ParseProperty(recordString.Substring(36, 1)),
                Location = recordString.Substring(37, 7).Trim(),
                BaseLocationSuffix = recordString.Substring(44, 1).Trim(),
                AssocLocationSuffix = recordString.Substring(45, 1).Trim(),
                DiagramType = recordString.Substring(46, 1).Trim(),
                StpIndicator = (StpIndicator)_enumPropertyParsers["StpIndicator"].ParseProperty(recordString.Substring(79, 1))
            };

            var dateFromResult = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = recordString.Substring(15, 6)
            });

            if (dateFromResult.HasValue)
                record.DateFrom = dateFromResult.Value;
            else
                throw new ArgumentException("Failed to parse Date From for Association record.");

            return record;
        }
    }
}