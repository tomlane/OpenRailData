using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
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