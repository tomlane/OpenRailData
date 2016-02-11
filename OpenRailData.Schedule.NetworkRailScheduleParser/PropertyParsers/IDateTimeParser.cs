using System;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public interface IDateTimeParser
    {
        DateTime? ParseDateTime(DateTimeParserRequest request);
    }

    public class DateTimeParserRequest
    {
        public string DateTimeString { get; set; } = string.Empty;
        public string DateTimeFormat { get; set; } = string.Empty;
    }
}