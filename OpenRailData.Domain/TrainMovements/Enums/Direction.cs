using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum Direction
    {
        [Display(Name = "Up")]
        Up,

        [Display(Name = "Down")]
        Down
    }
}