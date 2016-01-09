using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class ReservationsDetailsParser : IReservationDetailsParser
    {
        public ReservationDetails ParseTrainResevationDetails(string reservationDetails)
        {
            if (reservationDetails == null)
                throw new ArgumentNullException(nameof(reservationDetails));

            switch (reservationDetails)
            {
                case "A":
                    return ReservationDetails.Compulsory;
                case "E":
                    return ReservationDetails.BicyclesEssential;
                case "R":
                    return ReservationDetails.Recommended;
                case "S":
                    return ReservationDetails.PossibleFromAnyStation;
                default:
                    return ReservationDetails.None;
            }
        }
    }
}