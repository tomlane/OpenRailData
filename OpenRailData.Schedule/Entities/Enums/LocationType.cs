using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum LocationType
    {
        /// <summary>
        /// Origin location.
        /// </summary>
        [Display(Name = "Origin location")]
        LO = 1,
        /// <summary>
        /// Intermediate location.
        /// </summary>
        [Display(Name = "Intermediate location")]
        LI = 2,
        /// <summary>
        /// Terminating location.
        /// </summary>
        [Display(Name = "Terminating location")]
        LT = 3
    }
}