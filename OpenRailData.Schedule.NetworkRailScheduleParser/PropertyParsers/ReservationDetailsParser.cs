using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class ReservationDetailsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ReservationDetails";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            ReservationDetails result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : ReservationDetails.None;
        }
    }
}