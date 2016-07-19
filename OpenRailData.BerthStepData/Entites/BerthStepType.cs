using System.ComponentModel.DataAnnotations;

namespace OpenRailData.BerthStepData.Entites
{
    public enum BerthStepType
    {
        /// <summary>
        /// A between step. 
        /// </summary>
        [Display(Name = "Between")]
        B,
        /// <summary>
        /// A from step.
        /// </summary>
        [Display(Name = "From")]
        F,
        /// <summary>
        /// A to step.
        /// </summary>
        [Display(Name = "To")]
        T,
        /// <summary>
        /// An intermediate first step.
        /// </summary>
        [Display(Name = "Intermediate First")]
        D,
        /// <summary>
        /// A clearout step.
        /// </summary>
        [Display(Name = "Clearout")]
        C,
        /// <summary>
        /// A interpose step.
        /// </summary>
        [Display(Name = "Interpose")]
        I,
        /// <summary>
        /// A intermediate step.
        /// </summary>
        [Display(Name = "Intermediate")]
        E,
        /// <summary>
        /// An unknown step.
        /// </summary>
        [Display(Name = "Unknown / Failed to parse")]
        Unknown
    }
}