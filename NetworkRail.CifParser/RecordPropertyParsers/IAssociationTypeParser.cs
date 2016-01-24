using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IAssociationTypeParser
    {
        AssociationType ParseAssociationType(string associationType);
    }
}