using System.ComponentModel;

namespace OpenRailData.Domain.TrainDescriber
{
    public enum CClassMessageType
    {
        [Description("Berth Step")]
        BerthStep,

        [Description("Berth Cancel")]
        BerthCancel,

        [Description("Berth Interpose")]
        BerthInterpose,

        [Description("Heartbeat")]
        Heartbeat
    }
}