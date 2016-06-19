using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum ServiceBranding
    {
        /// <summary>
        /// None.
        /// </summary>
        [Display(Name = "None")]
        None = 0,
        /// <summary>
        /// Eurostar.
        /// </summary>
        [Display(Name = "Eurostar")]
        E = 1
    }
}