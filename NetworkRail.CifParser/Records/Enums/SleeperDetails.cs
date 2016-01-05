using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum SleeperDetails
    {
        [Description("Not Available")]
        NotAvailable = 0,

        [Description("First and Standard SleeperDetails")]
        FirstAndStandard = 1,

        [Description("First Class SleeperDetails Only")]
        FirstClassOnly = 2,

        [Description("Standard Class SleeperDetails Only")]
        StandardClassOnly = 3
    }
}