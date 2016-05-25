using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum EventType
    {
        [Display(Name = "Arrival")]
        ARRIVAL,

        [Display(Name = "Departure")]
        DEPARTURE,

        [Display(Name = "Destination")]
        DESTINATION
    }
}