using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class CateringCodeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "CateringCode";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            propertyString = string.Join<char>(", ", propertyString.Trim());

            CateringCode result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : 0;
        }
    }
}