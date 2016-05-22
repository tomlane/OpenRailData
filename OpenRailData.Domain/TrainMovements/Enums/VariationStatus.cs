using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum VariationStatus
    {
        [Display(Name = "On Time")]
        OnTime,

        [Display(Name = "Early")]
        Early,

        [Display(Name = "Late")]
        Late,

        [Display(Name = "Off Route")]
        OffRoute
    }
}