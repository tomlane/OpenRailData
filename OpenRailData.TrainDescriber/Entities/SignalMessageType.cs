using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainDescriber.Entities
{
    public enum SignalMessageType
    {
        /// <summary>
        /// Signal update.
        /// </summary>
        [Display(Name = "Signal Update")]
        Update,
        /// <summary>
        /// Signal refresh
        /// </summary>
        [Display(Name = "Signal Refresh")]
        Refresh,
        /// <summary>
        /// Signal refresh finished.
        /// </summary>
        [Display(Name = "Signal Refresh Finished")]
        RefreshFinished
    }
}