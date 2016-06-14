using System;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.ScheduleParsing.PropertyParsers
{
    public class PowerTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "PowerType";

        public Enum ParseProperty(string propertyString)
        {
            PowerType result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : PowerType.None;
        }
    }
}