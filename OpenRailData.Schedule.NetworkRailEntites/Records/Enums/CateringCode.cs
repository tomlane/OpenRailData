using System;
using System.ComponentModel;

namespace OpenRailData.Schedule.NetworkRailEntites.Records.Enums
{
    [Flags]
    public enum CateringCode
    {
        [Description("Buffet Service")]
        C = 1 << 0,

        [Description("Restaurance Car available for First Class passengers")]
        F = 1 << 1,

        [Description("Hot food available")]
        H = 1 << 2,

        [Description("Meal included for First Class passengers")]
        M = 1 << 3,

        [Description("Wheelchair only reservations")]
        P = 1 << 4,

        [Description("Restaurant")]
        R = 1 << 5,

        [Description("Trolley service")]
        T = 1 << 6
    }
}