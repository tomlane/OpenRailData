using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum ScheduleType
    {
        [Display(Name = "Permanent Schedule")]
        Permanent,

        [Display(Name = "Overlay Schedule")]
        Overlay,

        [Display(Name = "New Schedule")]
        New,

        [Display(Name = "Schedule Cancellation")]
        Cancellation
    }
}