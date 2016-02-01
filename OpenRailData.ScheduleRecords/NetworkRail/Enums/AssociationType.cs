using System.ComponentModel;

namespace OpenRailData.ScheduleRecords.NetworkRail.Enums
{
    public enum AssociationType
    {
        [Description("None")]
        None = 0,

        [Description("Passenger Use")]
        P = 1,

        [Description("Operating Use Only")]
        O = 2
    }
}