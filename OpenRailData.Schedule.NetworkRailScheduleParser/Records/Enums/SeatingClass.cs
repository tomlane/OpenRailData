using System.ComponentModel;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums
{
    public enum SeatingClass
    {
        [Description("First and Standard Class")]
        B = 1,

        [Description("Standard Class Only")]
        S = 2
    }
}