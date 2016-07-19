using System.ComponentModel.DataAnnotations;

namespace OpenRailData.BerthStepData.Entites
{
    public enum BerthEvent
    {
        /// <summary>
        /// An arrival in the 'up' direction.
        /// </summary>
        [Display(Name = "Arrive Up")]
        A,
        /// <summary>
        /// A departure in the 'up' direction.
        /// </summary>
        [Display(Name = "Depart Up")]
        B,
        /// <summary>
        /// An arrival in the 'down' direction.
        /// </summary>
        [Display(Name = "Arrive Down")]
        C,
        /// <summary>
        /// A departure in the 'down' direction.
        /// </summary>
        [Display(Name = "Depart Down")]
        D,
        /// <summary>
        /// Unknown berth event. 
        /// </summary>
        [Display(Name = "Unknown / Could not parse")]
        Unknown
    }
}