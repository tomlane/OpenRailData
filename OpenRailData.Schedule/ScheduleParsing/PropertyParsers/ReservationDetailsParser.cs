using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
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