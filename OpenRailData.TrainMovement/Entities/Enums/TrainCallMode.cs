using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainMovement.Entities.Enums
{
    public enum TrainCallMode
    {
        /// <summary>
        /// Normal.
        /// </summary>
        [Display(Name = "Normal")]
        NORMAL,
        /// <summary>
        /// Overnight.
        /// </summary>
        [Display(Name = "Overnight")]
        OVERNIGHT
    }
}