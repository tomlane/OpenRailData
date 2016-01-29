using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum LocationType
    {
        [Description("Origin location")]
        LO = 1,

        [Description("Intermediate location")]
        LI = 2,

        [Description("Terminating location")]
        LT = 3
    }
}