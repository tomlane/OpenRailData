using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum AssociationType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Passenger Use")]
        P = 1,

        [Display(Name = "Operating Use Only")]
        O = 2
    }
}