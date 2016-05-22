using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum LocationType
    {
        [Display(Name = "Origin location")]
        LO = 1,

        [Display(Name = "Intermediate location")]
        LI = 2,

        [Display(Name = "Terminating location")]
        LT = 3
    }
}