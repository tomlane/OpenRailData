using System;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
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