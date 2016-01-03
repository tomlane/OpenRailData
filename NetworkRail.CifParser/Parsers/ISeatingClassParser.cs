using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface ISeatingClassParser
    {
        SeatingClass ParseSeatingClass(string seatingClass);
    }
}