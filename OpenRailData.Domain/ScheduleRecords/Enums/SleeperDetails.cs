using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum SleeperDetails
    {
        [Display(Name = "Not Available")]
        NotAvailable = 0,

        [Display(Name = "First and Standard Sleepers")]
        B = 1,

        [Display(Name = "First Class Sleepers Only")]
        F = 2,

        [Display(Name = "Standard Class Sleepers Only")]
        S = 3
    }
}