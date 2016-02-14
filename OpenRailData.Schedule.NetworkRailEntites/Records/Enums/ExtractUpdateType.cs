using System.ComponentModel;

namespace OpenRailData.Schedule.NetworkRailEntites.Records.Enums
{
    public enum ExtractUpdateType
    {
        [Description("Full Extract")]
        F = 1,

        [Description("Update Extract")]
        U = 2
    }
}