using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
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