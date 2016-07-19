using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainMovement.Entities.Enums
{
    public enum ScheduleType
    {
        /// <summary>
        /// Permanent schedule.
        /// </summary>
        [Display(Name = "Permanent Schedule")]
        P,
        /// <summary>
        /// Overlay schedule.
        /// </summary>
        [Display(Name = "Overlay Schedule")]
        O,
        /// <summary>
        /// New schedule.
        /// </summary>
        [Display(Name = "New Schedule")]
        N,
        /// <summary>
        /// Cancellation schedule.
        /// </summary>
        [Display(Name = "Cancellation Schedule")]
        C
    }
}