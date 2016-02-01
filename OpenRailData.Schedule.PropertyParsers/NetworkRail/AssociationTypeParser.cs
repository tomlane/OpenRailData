using System;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
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