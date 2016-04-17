using System.ComponentModel;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum ExtractUpdateType
    {
        [Description("Full Extract")]
        F = 1,

        [Description("Update Extract")]
        U = 2
    }
}