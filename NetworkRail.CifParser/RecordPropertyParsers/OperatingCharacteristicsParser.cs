using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
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