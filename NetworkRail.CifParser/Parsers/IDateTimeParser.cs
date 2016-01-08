using System;

namespace NetworkRail.CifParser.Parsers
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