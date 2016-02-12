using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers
{
    public class HeaderCifRecordParser : IScheduleRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers;
        private readonly IDateTimeParser _dateTimeParser;

        public HeaderCifRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers, IDateTimeParser dateTimeParser)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));
            if (dateTimeParser == null)
                throw new ArgumentNullException(nameof(dateTimeParser));

            _dateTimeParser = dateTimeParser;
            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
        }

        public string RecordKey { get; } = "HD";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new HeaderRecord
            {
                RecordIdentity = ScheduleRecordType.HD,
                MainFrameIdentity = recordString.Substring(2, 20),
                TimeOfExtract = recordString.Substring(28, 4)
            };

            var mainFrameUserRegex = new Regex("TPS.U(.{6}).PD(.{6})");

            if (!mainFrameUserRegex.IsMatch(record.MainFrameIdentity))
                throw new InvalidOperationException("The main frame id is not valid in the header record.");
            
            var dateOfExtractResult = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddMMyy",
                DateTimeString = recordString.Substring(22, 6)
            });

            if (dateOfExtractResult.HasValue)
                record.DateOfExtract = dateOfExtractResult.Value;
            else
                throw new ArgumentException("Failed to parse Date of Extract in Header Record");

            var userExtractStartDateResult = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddMMyy",
                DateTimeString = recordString.Substring(48, 6)
            });

            if (userExtractStartDateResult.HasValue)
                record.UserExtractStartDate = userExtractStartDateResult.Value;
            else
                throw new ArgumentException("Failed to parse User Extract Start Date in Header Record");

            var userExtractEndDateResult = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddMMyy",
                DateTimeString = recordString.Substring(54, 6)
            });

            if (userExtractEndDateResult.HasValue)
                record.UserExtractEndDate = userExtractEndDateResult.Value;
            else
                throw new ArgumentException("Failed to parse User Extract End Date in Header Record");

            var mainFrameExtractDateResult = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = record.MainFrameIdentity.Substring(14, 6)
            });

            if (mainFrameExtractDateResult.HasValue)
                record.MainFrameExtractDate = mainFrameExtractDateResult.Value;
            else
                throw new ArgumentException("Failed to parse User Extract End Date in Header Record");
            
            record.CurrentFileRef = recordString.Substring(32, 7);
            record.LastFileRef = recordString.Substring(39, 7);
            record.ExtractUpdateType = (ExtractUpdateType)_enumPropertyParsers["ExtractUpdateType"].ParseProperty(recordString.Substring(46, 1));
            record.CifSoftwareVersion = recordString.Substring(47, 1);
            
            record.MainFrameUser = record.MainFrameIdentity.Substring(5, 6);

            return record;
        }
    }
}