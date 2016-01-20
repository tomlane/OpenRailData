using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IAssociationCategoryParser
    {
        AssociationCategory ParseAssociationCategory(string associationCategory);
    }
}