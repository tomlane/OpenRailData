using System;
using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    [Flags]
    public enum OperatingCharacteristics
    {
        [Display(Name = "Vacuum Braked.")]
        B = 1 << 0,

        [Display(Name = "Timed at 100mph.")]
        C = 1 << 1,

        [Display(Name = "Driver Only Operation.")]
        D = 1 << 2,

        [Display(Name = "Conveys Mark 4 Coaches.")]
        E = 1 << 3,

        [Display(Name = "Trainman (Guard) required.")]
        G = 1 << 4,

        [Display(Name = "Timed at 110mph.")]
        M = 1 << 5,

        [Display(Name = "Push/Pull train.")]
        P = 1 << 6,

        [Display(Name = "Runs as required.")]
        Q = 1 << 7,

        [Display(Name = "Air conditioned with PA system.")]
        R = 1 << 8,

        [Display(Name = "Steam Heated.")]
        S = 1 << 9,

        [Display(Name = "Runs to Terminals/Yards as required.")]
        Y = 1 << 10,

        [Display(Name = "May convey traffic to SB1C gauge. Not to be diverted from booked route without authority.")]
        Z = 1 << 11
    }
}