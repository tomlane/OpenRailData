using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum DateIndicator
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Standard (same day)")]
        S = 1,

        [Display(Name = "Over next midnight")]
        N = 2,

        [Display(Name = "Over previous midnight")]
        P = 3
    }
}