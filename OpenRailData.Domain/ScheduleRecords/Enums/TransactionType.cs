using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum TransactionType
    {
        [Display(Name = "New CIF Record")]
        N = 1,

        [Display(Name = "Revise CIF Record")]
        R = 2,

        [Display(Name = "Delete CIF Record")]
        D = 3,
    }
}