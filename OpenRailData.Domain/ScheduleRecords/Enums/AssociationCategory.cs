using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum AssociationCategory
    {
        /// <summary>
        /// No association category.
        /// </summary>
        [Display(Name = "None")]
        None = 0,
        /// <summary>
        /// A join association.
        /// </summary>
        [Display(Name = "Join")]
        JJ = 1,
        /// <summary>
        /// A split association.
        /// </summary>
        [Display(Name = "Split")]
        VV = 2,
        /// <summary>
        /// A next association. 
        /// </summary>
        [Display(Name = "Next")]
        NP = 3
    }
}