using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum ScheduleType
    {
        [Display(Name = "Permanent Schedule")]
        P,

        [Display(Name = "Overlay Schedule")]
        O,

        [Display(Name = "New Schedule")]
        N,

        [Display(Name = "Schedule Cancellation")]
        C
    }
}