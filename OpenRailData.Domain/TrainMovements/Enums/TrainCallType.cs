using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum TrainCallType
    {
        [Display(Name = "Automatic")]
        AUTOMATIC,

        [Display(Name = "Manual")]
        MANUAL
    }
}