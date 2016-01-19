using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class ChangesEnRouteRecordParserContainer : IChangesEnRouteRecordParserContainer
    {
        public ISeatingClassParser SeatingClassParser { get; }
        public ISleeperDetailsParser SleeperDetailsParser { get; }
        public IReservationDetailsParser ReservationDetailsParser { get; }

        public ChangesEnRouteRecordParserContainer(ISeatingClassParser seatingClassParser, ISleeperDetailsParser sleeperDetailsParser, IReservationDetailsParser reservationDetailsParser)
        {
            if (seatingClassParser == null)
                throw new ArgumentNullException(nameof(seatingClassParser));
            if (sleeperDetailsParser == null)
                throw new ArgumentNullException(nameof(sleeperDetailsParser));
            if (reservationDetailsParser == null)
                throw new ArgumentNullException(nameof(reservationDetailsParser));

            SeatingClassParser = seatingClassParser;
            SleeperDetailsParser = sleeperDetailsParser;
            ReservationDetailsParser = reservationDetailsParser;
        }
    }
}