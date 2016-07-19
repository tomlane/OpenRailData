using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum DateIndicator
    {
        /// <summary>
        /// None.
        /// </summary>
        [Display(Name = "None")]
        None = 0,
        /// <summary>
        /// Standard (same day).
        /// </summary>
        [Display(Name = "Standard (same day)")]
        S = 1,
        /// <summary>
        /// Over next midnight.
        /// </summary>
        [Display(Name = "Over next midnight")]
        N = 2,
        /// <summary>
        /// Over previous midnight.
        /// </summary>
        [Display(Name = "Over previous midnight")]
        P = 3
    }
}