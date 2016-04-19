using System.ComponentModel;

namespace OpenRailData.Domain.ReferenceData
{
    public enum BerthEvent
    {
        [Description("Arrive Up")]
        A,
        [Description("Depart Up")]
        B,
        [Description("Arrive Down")]
        C,
        [Description("Depart Down")]
        D,
        [Description("Unknown / Could not parse")]
        Unknown
    }
}