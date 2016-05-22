using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum SeatingClass
    {
        [Display(Name = "First and Standard Class")]
        B = 1,

        [Display(Name = "Standard Class Only")]
        S = 2
    }
}