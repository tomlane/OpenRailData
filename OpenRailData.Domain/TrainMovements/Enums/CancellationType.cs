using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum CancellationType
    {
        [Display(Name = "On Call")]
        ONCALL,

        [Display(Name = "At Origin")]
        ATORIGIN,

        [Display(Name = "En Route")]
        ENROUTE,

        [Display(Name = "Out of Plan")]
        OUTOFPLAN
    }
}