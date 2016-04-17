using System.ComponentModel;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum SeatingClass
    {
        [Description("First and Standard Class")]
        B = 1,

        [Description("Standard Class Only")]
        S = 2
    }
}