using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class PowerTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "PowerType";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            PowerType result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : PowerType.None;
        }
    }
}