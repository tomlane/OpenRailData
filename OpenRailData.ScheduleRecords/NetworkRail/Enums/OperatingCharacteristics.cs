using System;
using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    [Flags]
    public enum OperatingCharacteristics
    {
        [Description("Vacuum Braked.")]
        B = 1 << 0,

        [Description("Timed at 100mph.")]
        C = 1 << 1,

        [Description("Driver Only Operation.")]
        D = 1 << 2,

        [Description("Conveys Mark 4 Coaches.")]
        E = 1 << 3,

        [Description("Trainman (Guard) required.")]
        G = 1 << 4,

        [Description("Timed at 110mph.")]
        M = 1 << 5,

        [Description("Push/Pull train.")]
        P = 1 << 6,

        [Description("Runs as required.")]
        Q = 1 << 7,

        [Description("Air conditioned with PA system.")]
        R = 1 << 8,

        [Description("Steam Heated.")]
        S = 1 << 9,

        [Description("Runs to Terminals/Yards as required.")]
        Y = 1 << 10,

        [Description("May convey traffic to SB1C gauge. Not to be diverted from booked route without authority.")]
        Z = 1 << 11
    }
}