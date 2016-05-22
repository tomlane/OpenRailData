using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum ServiceBranding
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Eurostar")]
        E = 1
    }
}