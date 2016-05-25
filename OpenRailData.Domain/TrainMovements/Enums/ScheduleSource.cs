using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum ScheduleSource
    {
        [Display(Name = "CIF")]
        C,

        [Display(Name = "Very Short Term Plan")]
        V
    }
}