using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
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