using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum EventType
    {
        [Display(Name = "Arrival")]
        Arrival,

        [Display(Name = "Departure")]
        Departure,

        [Display(Name = "Destination")]
        Destination
    }
}