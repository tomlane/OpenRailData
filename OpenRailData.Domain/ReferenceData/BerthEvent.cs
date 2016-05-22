using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ReferenceData
{
    public enum BerthEvent
    {
        [Display(Name = "Arrive Up")]
        A,
        [Display(Name = "Depart Up")]
        B,
        [Display(Name = "Arrive Down")]
        C,
        [Display(Name = "Depart Down")]
        D,
        [Display(Name = "Unknown / Could not parse")]
        Unknown
    }
}