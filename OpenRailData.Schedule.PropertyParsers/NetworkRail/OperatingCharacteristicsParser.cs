using System;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
{
    public class OperatingCharacteristicsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "OperatingCharacteristics";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            propertyString = string.Join<char>(", ", propertyString.Trim());

            OperatingCharacteristics result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : 0;
        }
    }
}