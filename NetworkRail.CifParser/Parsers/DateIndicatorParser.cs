using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class DateIndicatorParser : IDateIndicatorParser
    {
        public DateIndicator ParseDateIndicator(string dateIndicator)
        {
            switch (dateIndicator)
            {
                case "S":
                    return DateIndicator.Standard;
                case "N":
                    return DateIndicator.Overnight;
                case "P":
                    return DateIndicator.PreviousNight;
                default:
                    throw new ArgumentException($"Unknown Date Indicator: {dateIndicator}");
            }
        }
    }
}