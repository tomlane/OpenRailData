using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainMovement.Entities.Enums
{
    public enum TrainCallType
    {
        /// <summary>
        /// Automatic.
        /// </summary>
        [Display(Name = "Automatic")]
        AUTOMATIC,
        /// <summary>
        /// Manual.
        /// </summary>
        [Display(Name = "Manual")]
        MANUAL
    }
}