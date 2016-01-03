using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class ChangesEnRouteRecordParserContainer : IChangesEnRouteRecordParserContainer
    {
        public ISeatingClassParser SeatingClassParser { get; set; }
        public ISleeperDetailsParser SleeperDetailsParser { get; set; }
        public IReservationDetailsParser ReservationDetailsParser { get; set; }

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