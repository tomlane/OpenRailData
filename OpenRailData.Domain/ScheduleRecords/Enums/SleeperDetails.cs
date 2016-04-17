using System.ComponentModel;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum SleeperDetails
    {
        [Description("Not Available")]
        NotAvailable = 0,

        [Description("First and Standard Sleepers")]
        B = 1,

        [Description("First Class Sleepers Only")]
        F = 2,

        [Description("Standard Class Sleepers Only")]
        S = 3
    }
}