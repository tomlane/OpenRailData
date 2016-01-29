using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum LocationRecordType
    {
        [Description("Origin Location")]
        Origin = 1,

        [Description("Intermediate Location")]
        Intermediate = 2,

        [Description("Terminating Location")]
        Terminating = 3
    }
}