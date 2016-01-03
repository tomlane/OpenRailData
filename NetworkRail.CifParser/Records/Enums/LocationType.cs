using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum LocationType
    {
        [Description("Originating")]
        Originating = 1,

        [Description("Intermediate")]
        Intermediate = 2,

        [Description("Terminating")]
        Terminating = 3
    }
}