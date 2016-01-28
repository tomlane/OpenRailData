using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum TransactionType
    {
        [Description("New")]
        N = 1,

        [Description("Revise")]
        R = 2,

        [Description("Delete")]
        D = 3
    }
}