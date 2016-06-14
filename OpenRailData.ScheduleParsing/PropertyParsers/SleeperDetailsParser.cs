using System;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.ScheduleParsing.PropertyParsers
{
    public class SleeperDetailsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "SleeperDetails";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                return SleeperDetails.NotAvailable;

            SleeperDetails result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : SleeperDetails.NotAvailable;
        }
    }
}