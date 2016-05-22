using System.ComponentModel;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum TrainCallType
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}