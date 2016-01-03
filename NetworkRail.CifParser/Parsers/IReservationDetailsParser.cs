using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IReservationDetailsParser
    {
        ReservationDetails ParseTrainResevationDetails(string reservationDetails);
    }
}