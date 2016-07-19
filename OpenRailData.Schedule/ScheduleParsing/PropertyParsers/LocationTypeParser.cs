using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class LocationTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "LocationType";

        public Enum ParseProperty(string propertyString)
        {
            if (string.IsNullOrWhiteSpace(propertyString))
                throw new ArgumentNullException(nameof(propertyString));

            return (LocationType)Enum.Parse(typeof(LocationType), propertyString);
        }
    }
}