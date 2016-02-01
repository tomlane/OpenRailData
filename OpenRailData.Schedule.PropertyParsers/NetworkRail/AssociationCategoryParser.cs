using System;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
{
    public class AssociationCategoryParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "AssociationCategory";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            AssociationCategory result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : AssociationCategory.None;
        }
    }
}