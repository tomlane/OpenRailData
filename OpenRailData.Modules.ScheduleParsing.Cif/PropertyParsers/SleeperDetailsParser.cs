using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
{
    public class SleeperDetailsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "SleeperDetails";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            SleeperDetails result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : SleeperDetails.NotAvailable;
        }
    }
}