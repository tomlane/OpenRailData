using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum BankHolidayRunning
    {
        [Display(Name = "Runs on bank holidays")]
        R = 1,

        [Display(Name = "Does not run on Glasgow bank holidays")]
        G = 2,

        [Display(Name = "Does not run on bank holidays")]
        X = 3
    }
}