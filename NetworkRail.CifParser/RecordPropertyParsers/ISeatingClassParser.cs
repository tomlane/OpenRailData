using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface ISeatingClassParser
    {
        SeatingClass ParseSeatingClass(string seatingClass);
    }
}