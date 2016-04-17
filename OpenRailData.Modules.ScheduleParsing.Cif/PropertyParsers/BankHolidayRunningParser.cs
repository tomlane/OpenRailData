using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
{
    public class BankHolidayRunningParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "BankHolidayRunning";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            BankHolidayRunning result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : BankHolidayRunning.R;
        }
    }
}