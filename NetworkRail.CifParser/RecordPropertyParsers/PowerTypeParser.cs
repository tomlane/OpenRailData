using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class PowerTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "PowerType";

        public Enum ParseProperty(string propertyString)
        {
            if (string.IsNullOrWhiteSpace(propertyString))
                throw new ArgumentNullException(nameof(propertyString));

            return (PowerType)Enum.Parse(typeof(PowerType), propertyString);
        }
    }
}