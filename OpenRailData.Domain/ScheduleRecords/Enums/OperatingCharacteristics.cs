using System;
using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    [Flags]
    public enum OperatingCharacteristics
    {
        /// <summary>
        /// Vacuum braked.
        /// </summary>
        [Display(Name = "Vacuum Braked.")]
        B = 1 << 0,
        /// <summary>
        /// Timed at 100mph.
        /// </summary>
        [Display(Name = "Timed at 100mph.")]
        C = 1 << 1,
        /// <summary>
        /// Driver only operation.
        /// </summary>
        [Display(Name = "Driver Only Operation.")]
        D = 1 << 2,
        /// <summary>
        /// Conveys mark 4 coaches.
        /// </summary>
        [Display(Name = "Conveys Mark 4 Coaches.")]
        E = 1 << 3,
        /// <summary>
        /// Trainman (guard) required.
        /// </summary>
        [Display(Name = "Trainman (Guard) required.")]
        G = 1 << 4,
        /// <summary>
        /// Timed at 110mph.
        /// </summary>
        [Display(Name = "Timed at 110mph.")]
        M = 1 << 5,
        /// <summary>
        /// Push/pull train.
        /// </summary>
        [Display(Name = "Push/Pull train.")]
        P = 1 << 6,
        /// <summary>
        /// Runs as required.
        /// </summary>
        [Display(Name = "Runs as required.")]
        Q = 1 << 7,
        /// <summary>
        /// Air conditioned with PA system.
        /// </summary>
        [Display(Name = "Air conditioned with PA system.")]
        R = 1 << 8,
        /// <summary>
        /// Steam heated.
        /// </summary>
        [Display(Name = "Steam Heated.")]
        S = 1 << 9,
        /// <summary>
        /// Runs to terminals/yards as required.
        /// </summary>
        [Display(Name = "Runs to Terminals/Yards as required.")]
        Y = 1 << 10,
        /// <summary>
        /// May convey traffic to SB1C gauge. Not to be diverted from booked route without authority.
        /// </summary>
        [Display(Name = "May convey traffic to SB1C gauge. Not to be diverted from booked route without authority.")]
        Z = 1 << 11
    }
}