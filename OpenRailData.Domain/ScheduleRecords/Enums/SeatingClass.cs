using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum SeatingClass
    {
        /// <summary>
        /// First and standard class.
        /// </summary>
        [Display(Name = "First and Standard Class")]
        B = 1,
        /// <summary>
        /// Standard class only.
        /// </summary>
        [Display(Name = "Standard Class Only")]
        S = 2
    }
}