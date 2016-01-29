using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class CateringCodeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "CateringCode";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            propertyString = string.Join<char>(", ", propertyString.Trim());

            CateringCode result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : 0;
        }
    }
}