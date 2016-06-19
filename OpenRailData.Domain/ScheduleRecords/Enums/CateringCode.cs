using System;
using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    [Flags]
    public enum CateringCode
    {
        /// <summary>
        /// Buffet Service.
        /// </summary>
        [Display(Name = "Buffet Service")]
        C = 1 << 0,
        /// <summary>
        /// Restaurant car for first class passengers.
        /// </summary>
        [Display(Name = "Restaurant Car available for First Class passengers")]
        F = 1 << 1,
        /// <summary>
        /// Hot food available.
        /// </summary>
        [Display(Name = "Hot food available")]
        H = 1 << 2,
        /// <summary>
        /// Meal included for first class passengers.
        /// </summary>
        [Display(Name = "Meal included for First Class passengers")]
        M = 1 << 3,
        /// <summary>
        /// Wheelchair only reservations.
        /// </summary>
        [Display(Name = "Wheelchair only reservations")]
        P = 1 << 4,
        /// <summary>
        /// Restaurant. 
        /// </summary>
        [Display(Name = "Restaurant")]
        R = 1 << 5,
        /// <summary>
        /// Trolley service.
        /// </summary>
        [Display(Name = "Trolley service")]
        T = 1 << 6,
        /// <summary>
        /// No catering / could not parse.
        /// </summary>
        [Display(Name = "None / Could not parse")]
        None = 1 << 7
    }
}