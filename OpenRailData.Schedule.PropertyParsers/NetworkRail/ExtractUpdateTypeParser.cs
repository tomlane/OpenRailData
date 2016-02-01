using System;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
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