using System;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
{
    public class DateIndicatorParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "DateIndicator";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            DateIndicator result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : DateIndicator.None;
        }
    }
}