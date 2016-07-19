using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class BankHolidayRunningParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "BankHolidayRunning";

        public Enum ParseProperty(string propertyString)
        {
            if (string.IsNullOrWhiteSpace(propertyString))
                return BankHolidayRunning.X;

            BankHolidayRunning result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : BankHolidayRunning.R;
        }
    }
}