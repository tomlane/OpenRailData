using System.ComponentModel;

namespace OpenRailData.Schedule.Records.NetworkRail.Enums
{
    public enum ExtractUpdateType
    {
        [Description("Full Extract")]
        F = 1,

        [Description("Update Extract")]
        U = 2
    }
}