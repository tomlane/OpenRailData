using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum TransactionType
    {
        /// <summary>
        /// New CIF record.
        /// </summary>
        [Display(Name = "New CIF Record")]
        N = 1,
        /// <summary>
        /// Revise CIF record.
        /// </summary>
        [Display(Name = "Revise CIF Record")]
        R = 2,
        /// <summary>
        /// Delete CIF record. 
        /// </summary>
        [Display(Name = "Delete CIF Record")]
        D = 3,
    }
}