using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainDescriber
{
    public enum BerthMessageType
    {
        [Display(Name = "Berth Step")]
        BerthStep,

        [Display(Name = "Berth Cancel")]
        BerthCancel,

        [Display(Name = "Berth Interpose")]
        BerthInterpose,

        [Display(Name = "Heartbeat")]
        Heartbeat
    }
}