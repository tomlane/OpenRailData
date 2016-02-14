using System.ComponentModel;

namespace OpenRailData.Schedule.NetworkRailEntites.Records.Enums
{
    public enum ReservationDetails
    {
        [Description("None")]
        None = 0,

        [Description("Compulsory")]
        A = 1,

        [Description("Bicyle Reservations Essential")]
        E = 2,

        [Description("Recommended")]
        R = 3,

        [Description("Possible From Any Station")]
        S = 4
    }
}