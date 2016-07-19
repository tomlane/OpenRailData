using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class DateIndicatorParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "DateIndicator";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            DateIndicator result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : DateIndicator.None;
        }
    }
}