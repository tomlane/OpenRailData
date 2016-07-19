using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum BankHolidayRunning
    {
        /// <summary>
        /// Runs on bank holidays.
        /// </summary>
        [Display(Name = "Runs on bank holidays")]
        R = 1,
        /// <summary>
        /// Does not run on Glasgow bank holidays.
        /// </summary>
        [Display(Name = "Does not run on Glasgow bank holidays")]
        G = 2,
        /// <summary>
        /// Does not run on bank holidays.
        /// </summary>
        [Display(Name = "Does not run on bank holidays")]
        X = 3
    }
}