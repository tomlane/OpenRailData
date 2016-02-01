using System.ComponentModel;

namespace OpenRailData.Schedule.Records.NetworkRail.Enums
{
    public enum BankHolidayRunning
    {
        [Description("Runs on bank holidays")]
        R = 1,

        [Description("Does not run on Glasgow bank holidays")]
        G = 2,

        [Description("Does not run on bank holidays")]
        X = 3
    }
}