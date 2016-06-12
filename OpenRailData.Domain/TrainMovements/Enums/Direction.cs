using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum Direction
    {
        [Display(Name = "Up")]
        UP,

        [Display(Name = "Down")]
        DOWN,

        [Display(Name = "None")]
        None
    }
}