using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum VariationStatus
    {
        /// <summary>
        /// On time.
        /// </summary>
        [Display(Name = "On Time")]
        ONTIME,
        /// <summary>
        /// Early.
        /// </summary>
        [Display(Name = "Early")]
        EARLY,
        /// <summary>
        /// Late.
        /// </summary>
        [Display(Name = "Late")]
        LATE,
        /// <summary>
        /// Off route.
        /// </summary>
        [Display(Name = "Off Route")]
        OFFROUTE
    }
}