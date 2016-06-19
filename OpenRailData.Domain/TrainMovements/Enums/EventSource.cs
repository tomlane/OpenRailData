using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum EventSource
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