using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum AssociationCategory
    {
        [Description("None")]
        None = 0,

        [Description("Join")]
        Join = 1,

        [Description("Split")]
        Split = 2,

        [Description("Next")]
        Next = 3
    }
}