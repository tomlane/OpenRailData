using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainMovement.Entities.Enums
{
    public enum EventType
    {
        /// <summary>
        /// Arrival.
        /// </summary>
        [Display(Name = "Arrival")]
        ARRIVAL,
        /// <summary>
        /// Departure.
        /// </summary>
        [Display(Name = "Departure")]
        DEPARTURE,
        /// <summary>
        /// Destination.
        /// </summary>
        [Display(Name = "Destination")]
        DESTINATION
    }
}