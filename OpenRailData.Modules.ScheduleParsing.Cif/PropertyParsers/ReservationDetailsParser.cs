using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
{
    public class ReservationDetailsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ReservationDetails";

        public Enum ParseProperty(string propertyString)
        {
            ReservationDetails result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : ReservationDetails.None;
        }
    }
}