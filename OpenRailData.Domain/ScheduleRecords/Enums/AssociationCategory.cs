using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum AssociationCategory
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Join")]
        JJ = 1,

        [Display(Name = "Split")]
        VV = 2,

        [Display(Name = "Next")]
        NP = 3
    }
}