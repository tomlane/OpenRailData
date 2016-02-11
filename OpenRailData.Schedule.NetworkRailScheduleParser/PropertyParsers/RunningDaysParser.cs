using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class RunningDaysParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "RunningDays";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            if (propertyString.Length != 7)
                throw new ArgumentException("Running Days must have a length of 7.");

            Days result = 0;

            if (propertyString.Substring(0, 1).Trim() == "1")
                result = result | Days.Monday;
            if (propertyString.Substring(1, 1).Trim() == "1")
                result = result | Days.Tuesday;
            if (propertyString.Substring(2, 1).Trim() == "1")
                result = result | Days.Wednesday;
            if (propertyString.Substring(3, 1).Trim() == "1")
                result = result | Days.Thursday;
            if (propertyString.Substring(4, 1).Trim() == "1")
                result = result | Days.Friday;
            if (propertyString.Substring(5, 1).Trim() == "1")
                result = result | Days.Saturday;
            if (propertyString.Substring(6, 1).Trim() == "1")
                result = result | Days.Sunday;

            return result;
        }
    }
}