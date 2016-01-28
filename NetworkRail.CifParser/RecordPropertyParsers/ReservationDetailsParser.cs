using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class ReservationDetailsParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ReservationDetails";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            ReservationDetails result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : ReservationDetails.None;
        }
    }
}