using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum DateIndicator
    {
        [Description("Standard")]
        Standard = 1,

        [Description("Overnight")]
        Overnight = 2,

        [Description("Previous Night")]
        PreviousNight = 3
    }
}