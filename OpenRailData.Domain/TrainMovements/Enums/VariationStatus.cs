using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum VariationStatus
    {
        [Display(Name = "On Time")]
        ONTIME,

        [Display(Name = "Early")]
        EARLY,

        [Display(Name = "Late")]
        LATE,

        [Display(Name = "Off Route")]
        OFFROUTE
    }
}