using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum ExtractUpdateType
    {
        [Description("Full Extract")]
        F = 1,

        [Description("Update Extract")]
        U = 2
    }
}