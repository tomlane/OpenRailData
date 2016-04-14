using System;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
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