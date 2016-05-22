using System.ComponentModel;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum EventSource
    {
        [Description("Automatic")]
        Automatic,

        [Description("Manual")]
        Manual
    }
}