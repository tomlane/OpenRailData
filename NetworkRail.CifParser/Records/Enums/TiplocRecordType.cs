using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum TiplocRecordType
    {
        [Description("Tiploc Insert Record")]
        Insert = 1,

        [Description("Tiploc Amend Record")]
        Amend = 2
    }
}