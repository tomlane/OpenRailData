using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class StpIndicatorParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "StpIndicator";

        public Enum ParseProperty(string propertyString)
        {
            if (string.IsNullOrWhiteSpace(propertyString))
                throw new ArgumentNullException(nameof(propertyString));

            return (StpIndicator)Enum.Parse(typeof(StpIndicator), propertyString);
        }
    }
}