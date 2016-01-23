using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum LocationType
    {
        [Description("Origin")]
        Origin = 1,

        [Description("Intermediate")]
        Intermediate = 2,

        [Description("Terminating")]
        Terminating = 3
    }
}