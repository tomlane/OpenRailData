using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class AssociationCategoryParser : IAssociationCategoryParser
    {
        public AssociationCategory ParseAssociationCategory(string associationCategory)
        {
            if (associationCategory == null)
                throw new ArgumentNullException(nameof(associationCategory));

            switch (associationCategory)
            {
                case "JJ":
                    return AssociationCategory.Join;
                case "VV":
                    return AssociationCategory.Split;
                case "NP":
                    return AssociationCategory.Next;
                default:
                    return AssociationCategory.None;
            }
        }
    }
}