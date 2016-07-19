using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum SleeperDetails
    {
        /// <summary>
        /// Not Available.
        /// </summary>
        [Display(Name = "Not Available")]
        NotAvailable = 0,
        /// <summary>
        /// First and standard sleepers.
        /// </summary>
        [Display(Name = "First and Standard Sleepers")]
        B = 1,
        /// <summary>
        /// First class sleepers only.
        /// </summary>
        [Display(Name = "First Class Sleepers Only")]
        F = 2,
        /// <summary>
        /// Standard class sleepers only.
        /// </summary>
        [Display(Name = "Standard Class Sleepers Only")]
        S = 3
    }
}