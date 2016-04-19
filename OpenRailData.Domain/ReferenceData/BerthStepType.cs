using System.ComponentModel;

namespace OpenRailData.Domain.ReferenceData
{
    public enum BerthStepType
    {
        [Description("Between")]
        B,
        [Description("From")]
        F,
        [Description("To")]
        T,
        [Description("Intermediate First")]
        D,
        [Description("Clearout")]
        C,
        [Description("Interpose")]
        I,
        [Description("Intermediate")]
        E,
        [Description("Unknown / Failed to parse")]
        Unknown
    }
}