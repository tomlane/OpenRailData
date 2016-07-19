using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class OperatingCharacteristicsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "OperatingCharacteristics";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                return (OperatingCharacteristics)0;

            propertyString = string.Join<char>(", ", propertyString.Trim());

            OperatingCharacteristics result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : 0;
        }
    }
}