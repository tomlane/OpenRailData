using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum BankHolidayRunning
    {
        [Description("Runs on bank holidays")]
        RunsOnBankHoliday = 1,

        [Description("Does not run on Glasgow bank holidays")]
        DoesNotRunGlasgow = 2,

        [Description("Does not run on bank holidays")]
        DoesNotRun = 3
    }
}