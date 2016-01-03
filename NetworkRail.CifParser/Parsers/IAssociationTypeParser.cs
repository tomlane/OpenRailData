using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IAssociationTypeParser
    {
        AssociationType ParseAssociationType(string associationType);
    }
}