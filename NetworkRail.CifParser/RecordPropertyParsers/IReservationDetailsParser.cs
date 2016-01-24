using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IReservationDetailsParser
    {
        ReservationDetails ParseTrainResevationDetails(string reservationDetails);
    }
}