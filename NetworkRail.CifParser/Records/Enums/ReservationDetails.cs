using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum ReservationDetails
    {
        [Description("Compulsory")]
        Compulsory = 1,

        [Description("Bicyle Reservation Essential")]
        BicyclesEssential = 2,

        [Description("Recommended")]
        Recommended = 3,

        [Description("Possible From Any Station")]
        PossibleFromAnyStation = 4
    }
}