using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    public enum ReservationDetails
    {
        /// <summary>
        /// None.
        /// </summary>
        [Display(Name = "None")]
        None = 0,
        /// <summary>
        /// Compulsory.
        /// </summary>
        [Display(Name = "Compulsory")]
        A = 1,
        /// <summary>
        /// Bicycle reservations essential.
        /// </summary>
        [Display(Name = "Bicycle Reservations Essential")]
        E = 2,
        /// <summary>
        /// Recommended.
        /// </summary>
        [Display(Name = "Recommended")]
        R = 3,
        /// <summary>
        /// Possible from any station.
        /// </summary>
        [Display(Name = "Possible From Any Station")]
        S = 4
    }
}