using System;
using System.Text.RegularExpressions;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class HeaderRecordBuilder : ICifRecordBuilder<HeaderRecord>
    {
        private readonly IHeaderRecordParserContainer _recordParserContainer;

        public HeaderRecordBuilder(IHeaderRecordParserContainer recordParserContainer)
        {
            if (recordParserContainer == null)
                throw new ArgumentNullException(nameof(recordParserContainer));

            _recordParserContainer = recordParserContainer;
        }

        public HeaderRecord BuildRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            HeaderRecord record = new HeaderRecord
            {
                MainFrameIdentity = recordString.Substring(2, 20)
            };

            Regex mainFrameUserRegex = new Regex("TPS.U(.{6}).PD(.{6})");

            if (!mainFrameUserRegex.IsMatch(record.MainFrameIdentity))
                throw new InvalidOperationException("The main frame id is not valid in the header record.");
            
            record.DateOfExtract = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddmmyy",
                DateTimeString = recordString.Substring(22, 6)
            });

            record.TimeOfExtract = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(28, 4));
            record.CurrentFileRef = recordString.Substring(32, 7);
            record.LastFileRef = recordString.Substring(39, 7);
            record.ExtractUpdateType = _recordParserContainer.UpdateTypeParser.ParseExtractUpdateType(recordString.Substring(46, 1));
            record.CifSoftwareVersion = recordString.Substring(47, 1);

            record.UserExtractStartDate = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddmmyy",
                DateTimeString = recordString.Substring(48, 6)
            });

            record.UserExtractEndDate = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddmmyy",
                DateTimeString = recordString.Substring(54, 6)
            });

            record.MainFrameUser = record.MainFrameIdentity.Substring(5, 6);

            record.MainFrameExtractDate = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yymmdd",
                DateTimeString = record.MainFrameIdentity.Substring(14, 6)
            });

            return record;
        }
    }
}