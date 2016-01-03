using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum SeatingClass
    {
        [Description("First and Standard Class")]
        FirstAndStandardClass = 1,

        [Description("Standard Class Only")]
        StandardClassOnly = 2
    }
}