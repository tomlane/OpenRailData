using System.ComponentModel;

namespace OpenRailData.Schedule.Records.NetworkRail.Enums
{
    public enum DateIndicator
    {
        [Description("None")]
        None = 0,

        [Description("Standard (same day)")]
        S = 1,

        [Description("Over next midnight")]
        N = 2,

        [Description("Over previous midnight")]
        P = 3
    }
}