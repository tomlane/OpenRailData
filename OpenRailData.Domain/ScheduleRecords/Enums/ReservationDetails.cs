using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum ReservationDetails
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Compulsory")]
        A = 1,

        [Display(Name = "Bicyle Reservations Essential")]
        E = 2,

        [Display(Name = "Recommended")]
        R = 3,

        [Display(Name = "Possible From Any Station")]
        S = 4
    }
}