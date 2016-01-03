using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum ExtractUpdateType
    {
        [Description("Full Extract")]
        FullExtract = 1,

        [Description("Update Extract")]
        UpdateExtract = 2
    }
}