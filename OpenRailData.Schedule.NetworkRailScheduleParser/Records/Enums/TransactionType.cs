using System.ComponentModel;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums
{
    public enum TransactionType
    {
        [Description("New CIF Record")]
        N = 1,

        [Description("Revise CIF Record")]
        R = 2,

        [Description("Delete CIF Record")]
        D = 3,

        [Description("JSON Create Record")]
        create = 1,

        [Description("JSON Update Record")]
        update = 2,

        [Description("Json Delete Record")]
        delete = 3
    }
}