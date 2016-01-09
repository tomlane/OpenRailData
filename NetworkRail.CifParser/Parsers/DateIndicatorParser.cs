using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class DateIndicatorParser : IDateIndicatorParser
    {
        public DateIndicator ParseDateIndicator(string dateIndicator)
        {
            if (dateIndicator == null)
                throw new ArgumentNullException(nameof(dateIndicator));

            switch (dateIndicator)
            {
                case "S":
                    return DateIndicator.Standard;
                case "N":
                    return DateIndicator.Overnight;
                case "P":
                    return DateIndicator.PreviousNight;
                default:
                    return DateIndicator.None;
            }
        }
    }
}