using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class AssociationCategoryParser : IAssociationCategoryParser
    {
        public AssociationCategory ParseAssociationCategory(string associationCategory)
        {
            switch (associationCategory)
            {
                case "JJ":
                    return AssociationCategory.Join;
                case "VV":
                    return AssociationCategory.Split;
                case "NP":
                    return AssociationCategory.Next;
                default:
                    throw new ArgumentException($"Unknown Association Category: {associationCategory}");
            }
        }
    }
}