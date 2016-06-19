using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum StpIndicator
    {
        /// <summary>
        /// Permanent schedule.
        /// </summary>
        [Display(Name = "Permanent Schedule")]
        P = 1,
        /// <summary>
        /// Overlay schedule.
        /// </summary>
        [Display(Name = "Overlay Schedule")]
        O = 2,
        /// <summary>
        /// New schedule.
        /// </summary>
        [Display(Name = "New Schedule")]
        N = 3,
        /// <summary>
        /// Schedule cancellation.
        /// </summary>
        [Display(Name = "Schedule Cancellation")]
        C = 4
    }
}