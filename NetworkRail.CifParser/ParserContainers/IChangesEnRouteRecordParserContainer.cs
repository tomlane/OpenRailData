using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IChangesEnRouteRecordParserContainer
    {
        ISeatingClassParser SeatingClassParser { get; }
        ISleeperDetailsParser SleeperDetailsParser { get; }
        IReservationDetailsParser ReservationDetailsParser { get; }
    }
}