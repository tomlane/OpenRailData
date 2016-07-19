using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum ExtractUpdateType
    {
        /// <summary>
        /// Full extract.
        /// </summary>
        [Display(Name = "Full Extract")]
        F = 1,
        /// <summary>
        /// Update extract.
        /// </summary>
        [Display(Name = "Update Extract")]
        U = 2
    }
}