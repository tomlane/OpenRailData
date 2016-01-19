using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IChangesEnRouteRecordParserContainer
    {
        ISeatingClassParser SeatingClassParser { get; }
        ISleeperDetailsParser SleeperDetailsParser { get; }
        IReservationDetailsParser ReservationDetailsParser { get; }
    }
}