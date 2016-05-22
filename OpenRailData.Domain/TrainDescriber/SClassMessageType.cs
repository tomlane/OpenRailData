using System.ComponentModel;

namespace OpenRailData.Domain.TrainDescriber
{
    public enum SClassMessageType
    {
        [Description("Signal Update")]
        Update,

        [Description("Signal Refesh")]
        Refresh,

        [Description("Signal Refresh Finished")]
        RefreshFinished
    }
}