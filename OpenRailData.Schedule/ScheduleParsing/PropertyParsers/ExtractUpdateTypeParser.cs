using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class ExtractUpdateTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ExtractUpdateType";

        public Enum ParseProperty(string propertyString)
        {
            if (string.IsNullOrWhiteSpace(propertyString))
                throw new ArgumentNullException(nameof(propertyString));
            
            return (ExtractUpdateType)Enum.Parse(typeof(ExtractUpdateType), propertyString);
        }
    }
}