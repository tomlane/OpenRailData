using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class SleeperDetailsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "SleeperDetails";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            SleeperDetails result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : SleeperDetails.NotAvailable;
        }
    }
}