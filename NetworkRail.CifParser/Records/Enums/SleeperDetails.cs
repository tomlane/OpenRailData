using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum SleeperDetails
    {
        [Description("Not Available")]
        NotAvailable = 0,

        [Description("First and Standard SleeperDetails")]
        B = 1,

        [Description("First Class SleeperDetails Only")]
        F = 2,

        [Description("Standard Class SleeperDetails Only")]
        S = 3
    }
}