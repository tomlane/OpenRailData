using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum LocationRecordType
    {
        [Description("Origin OriginLocation")]
        Origin = 1,

        [Description("Intermediate OriginLocation")]
        Intermediate = 2,

        [Description("Terminating OriginLocation")]
        Terminating = 3
    }
}