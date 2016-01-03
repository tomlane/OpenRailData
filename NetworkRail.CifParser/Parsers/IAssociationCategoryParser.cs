using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IAssociationCategoryParser
    {
        AssociationCategory ParseAssociationCategory(string associationCategory);
    }
}