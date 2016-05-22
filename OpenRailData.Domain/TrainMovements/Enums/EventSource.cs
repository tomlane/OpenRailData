using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum EventSource
    {
        [Display(Name = "Automatic")]
        Automatic,

        [Display(Name = "Manual")]
        Manual
    }
}