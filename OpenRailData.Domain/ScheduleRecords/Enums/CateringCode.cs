using System;
using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    [Flags]
    public enum CateringCode
    {
        [Display(Name = "Buffet Service")]
        C = 1 << 0,

        [Display(Name = "Restaurance Car available for First Class passengers")]
        F = 1 << 1,

        [Display(Name = "Hot food available")]
        H = 1 << 2,

        [Display(Name = "Meal included for First Class passengers")]
        M = 1 << 3,

        [Display(Name = "Wheelchair only reservations")]
        P = 1 << 4,

        [Display(Name = "Restaurant")]
        R = 1 << 5,

        [Display(Name = "Trolley service")]
        T = 1 << 6
    }
}