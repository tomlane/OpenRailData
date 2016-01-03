using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum StpIndicator
    {
        [Description("Permanent Schedule")]
        Permanent = 1,
        
        [Description("Overlay Schedule")]
        Overlay = 2,

        [Description("New Schedule")]
        New = 3,

        [Description("Schedule Cancellation")]
        Cancellation = 4
    }
}