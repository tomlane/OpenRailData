using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainDescriber
{
    public enum BerthMessageType
    {
        /// <summary>
        /// Berth step.
        /// </summary>
        [Display(Name = "Berth Step")]
        BerthStep,
        /// <summary>
        /// Berth cancel.
        /// </summary>
        [Display(Name = "Berth Cancel")]
        BerthCancel,
        /// <summary>
        /// Berth interpose.
        /// </summary>
        [Display(Name = "Berth Interpose")]
        BerthInterpose,
        /// <summary>
        /// Berth heartbeat.
        /// </summary>
        [Display(Name = "Heartbeat")]
        Heartbeat
    }
}