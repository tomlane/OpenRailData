using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum CancellationType
    {
        [Display(Name = "On Call")]
        OnCall,

        [Display(Name = "At Origin")]
        AtOrigin,

        [Display(Name = "En Route")]
        EnRoute,

        [Display(Name = "Out of Plan")]
        OutOfPlan
    }
}