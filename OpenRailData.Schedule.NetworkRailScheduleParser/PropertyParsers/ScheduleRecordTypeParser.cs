using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class ScheduleRecordTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ScheduleRecordType";

        public Enum ParseProperty(string propertyString)
        {
            if (string.IsNullOrWhiteSpace(propertyString))
                throw new ArgumentNullException(nameof(propertyString));

            return (ScheduleRecordType)Enum.Parse(typeof(ScheduleRecordType), propertyString);
        }
    }
}