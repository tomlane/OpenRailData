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
                RecordIdentity = CifRecordType.Header,
                MainFrameIdentity = recordString.Substring(2, 20)
            };

            Regex mainFrameUserRegex = new Regex("TPS.U(.{6}).PD(.{6})");

            if (!mainFrameUserRegex.IsMatch(record.MainFrameIdentity))
                throw new InvalidOperationException("The main frame id is not valid in the header record.");
            
            var dateOfExtractResult = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddMMyy",
                DateTimeString = recordString.Substring(22, 6)
            });

            if (dateOfExtractResult.HasValue)
                record.DateOfExtract = dateOfExtractResult.Value;
            else
                throw new ArgumentException("Failed to parse Date of Extract in Header Record");

            var userExtractStartDateResult = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddMMyy",
                DateTimeString = recordString.Substring(48, 6)
            });

            if (userExtractStartDateResult.HasValue)
                record.UserExtractStartDate = userExtractStartDateResult.Value;
            else
                throw new ArgumentException("Failed to parse User Extract Start Date in Header Record");

            var userExtractEndDateResult = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "ddMMyy",
                DateTimeString = recordString.Substring(54, 6)
            });

            if (userExtractEndDateResult.HasValue)
                record.UserExtractEndDate = userExtractEndDateResult.Value;
            else
                throw new ArgumentException("Failed to parse User Extract End Date in Header Record");

            var mainFrameExtractDateResult = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = record.MainFrameIdentity.Substring(14, 6)
            });

            if (mainFrameExtractDateResult.HasValue)
                record.MainFrameExtractDate = mainFrameExtractDateResult.Value;
            else
                throw new ArgumentException("Failed to parse User Extract End Date in Header Record");

            var timeOfExtractResult = _recordParserContainer.TimeParser.ParseTime(recordString.Substring(28, 4));

            if (timeOfExtractResult.HasValue)
                record.TimeOfExtract = timeOfExtractResult.Value;
            else
                throw new ArgumentNullException("Failed to parse Time of Extract in Header Record");
            
            record.CurrentFileRef = recordString.Substring(32, 7);
            record.LastFileRef = recordString.Substring(39, 7);
            record.ExtractUpdateType = _recordParserContainer.UpdateTypeParser.ParseExtractUpdateType(recordString.Substring(46, 1));
            record.CifSoftwareVersion = recordString.Substring(47, 1);
            
            record.MainFrameUser = record.MainFrameIdentity.Substring(5, 6);

            return record;
        }
    }
}