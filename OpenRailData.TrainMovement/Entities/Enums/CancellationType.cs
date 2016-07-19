using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainMovement.Entities.Enums
{
    public enum CancellationType
    {
        /// <summary>
        /// On call.
        /// </summary>
        [Display(Name = "On Call")]
        ONCALL,
        /// <summary>
        /// At origin.
        /// </summary>
        [Display(Name = "At Origin")]
        ATORIGIN,
        /// <summary>
        /// En route.
        /// </summary>
        [Display(Name = "En Route")]
        ENROUTE,
        /// <summary>
        /// Out of plan.
        /// </summary>
        [Display(Name = "Out of Plan")]
        OUTOFPLAN
    }
}