using System.ComponentModel;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum TrainCallMode
    {
        [Description("Normal")]
        Normal,

        [Description("Overnight")]
        Overnight
    }
}