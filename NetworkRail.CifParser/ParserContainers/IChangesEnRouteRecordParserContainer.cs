using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IChangesEnRouteRecordParserContainer
    {
        ISeatingClassParser SeatingClassParser { get; set; }
        ISleeperDetailsParser SleeperDetailsParser { get; set; }
        IReservationDetailsParser ReservationDetailsParser { get; set; }
    }
}