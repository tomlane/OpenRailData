using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.DarwinSchedule
{
    public enum DarwinSchedulePointType
    {
        /// <summary>
        /// Origin point.
        /// </summary>
        [Display(Name = "Origin")]
        OR,
        /// <summary>
        /// Passing point.
        /// </summary>
        [Display(Name = "Passing Point")]
        PP,
        /// <summary>
        /// Intermediate point (calls for passengers).
        /// </summary>
        [Display(Name = "Intermediate Point")]
        IP,
        /// <summary>
        /// Operational stop (not applicable to passengers).
        /// </summary>
        [Display(Name = "Operational Stop")]
        OPIP,
        /// <summary>
        /// Destination point.
        /// </summary>
        [Display(Name = "Destination")]
        DT
    }
}