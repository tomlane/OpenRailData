using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ReferenceData
{
    public enum BerthStepType
    {
        [Display(Name = "Between")]
        B,
        [Display(Name = "From")]
        F,
        [Display(Name = "To")]
        T,
        [Display(Name = "Intermediate First")]
        D,
        [Display(Name = "Clearout")]
        C,
        [Display(Name = "Interpose")]
        I,
        [Display(Name = "Intermediate")]
        E,
        [Display(Name = "Unknown / Failed to parse")]
        Unknown
    }
}