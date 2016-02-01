using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum SeatingClass
    {
        [Description("First and Standard Class")]
        B = 1,

        [Description("Standard Class Only")]
        S = 2
    }
}