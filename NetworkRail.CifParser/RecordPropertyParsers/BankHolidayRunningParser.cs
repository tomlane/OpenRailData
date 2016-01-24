using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class BankHolidayRunningParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "BankHolidayRunning";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            BankHolidayRunning result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : BankHolidayRunning.R;
        }
    }
}