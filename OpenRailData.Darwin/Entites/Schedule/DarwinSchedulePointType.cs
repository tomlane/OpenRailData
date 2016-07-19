using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Darwin.Entites.Schedule
{
    public enum DarwinSchedulePointType
    {
        /// <summary>
        /// Operational origin point (not applicable to passengers).
        /// </summary>
        [Display(Name = "Operational Origin")]
        OPOR,
        /// <summary>
        /// Public origin point.
        /// </summary>
        [Display(Name = "Public Origin")]
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
        /// Public destination point.
        /// </summary>
        [Display(Name = "Destination")]
        DT,
        /// <summary>
        /// Operational destination point (not applicable to passengers).
        /// </summary>
        [Display(Name = "Operational Destination")]
        OPDT
    }
}