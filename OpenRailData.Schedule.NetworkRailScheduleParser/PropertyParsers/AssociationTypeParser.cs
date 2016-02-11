using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class AssociationTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "AssociationType";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            AssociationType result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : AssociationType.None;
        }
    }
}