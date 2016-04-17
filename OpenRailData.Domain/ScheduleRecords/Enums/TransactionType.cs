using System.ComponentModel;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum TransactionType
    {
        [Description("New CIF Record")]
        N = 1,

        [Description("Revise CIF Record")]
        R = 2,

        [Description("Delete CIF Record")]
        D = 3,
    }
}