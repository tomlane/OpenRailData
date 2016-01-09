using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum ReservationDetails
    {
        [Description("None")]
        None = 0,

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