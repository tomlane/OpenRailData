using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum AssociationType
    {
        /// <summary>
        /// No association type.
        /// </summary>
        [Display(Name = "None")]
        None = 0,
        /// <summary>
        /// A association for passenger use.
        /// </summary>
        [Display(Name = "Passenger Use")]
        P = 1,
        /// <summary>
        /// A association used for operating use only. 
        /// </summary>
        [Display(Name = "Operating Use Only")]
        O = 2
    }
}