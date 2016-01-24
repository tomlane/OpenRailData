using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class DateIndicatorParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "DateIndicator";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            DateIndicator result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : DateIndicator.None;
        }
    }
}