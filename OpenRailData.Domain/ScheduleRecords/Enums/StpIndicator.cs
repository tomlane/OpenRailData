using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum StpIndicator
    {
        [Display(Name = "Permanent Schedule")]
        P = 1,
        
        [Display(Name = "Overlay Schedule")]
        O = 2,

        [Display(Name = "New Schedule")]
        N = 3,

        [Display(Name = "Schedule Cancellation")]
        C = 4
    }
}