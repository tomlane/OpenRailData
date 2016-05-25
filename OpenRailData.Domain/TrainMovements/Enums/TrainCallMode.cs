using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum TrainCallMode
    {
        [Display(Name = "Normal")]
        NORMAL,

        [Display(Name = "Overnight")]
        OVERNIGHT
    }
}