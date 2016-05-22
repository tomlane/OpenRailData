using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum ExtractUpdateType
    {
        [Display(Name = "Full Extract")]
        F = 1,

        [Display(Name = "Update Extract")]
        U = 2
    }
}