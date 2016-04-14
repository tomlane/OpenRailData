using System;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
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