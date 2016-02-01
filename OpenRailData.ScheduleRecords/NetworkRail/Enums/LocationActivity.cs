using System;
using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    [Flags]
    public enum LocationActivity
    {
        [Description("Stops or shunts for other trains to pass")]
        A = 1 << 0,

        [Description("Attach/detach assisting locomotive")]
        AE = 1 << 1,

        [Description("Shows as 'X' on arrival")]
        AX = 1 << 2,

        [Description("Stops for banking locomotive")]
        BL = 1 << 3,

        [Description("Stops to change trainmen")]
        C = 1 << 4,

        [Description("Stops to set down passengers")]
        D = 1 << 5,

        [Description("Stops to detach vehicles")]
        MinusD = 1 << 6,

        [Description("Stops for examination")]
        E = 1 << 7,

        [Description("National Rail Timetable data to add")]
        G = 1 << 8,

        [Description("Notional activity to prevent WTT timing columns merge")]
        H = 1 << 9,

        [Description("Notional activity to prevent WTT timing columns merge, with third column")]
        HH = 1 << 10,

        [Description("Passenger count point")]
        K = 1 << 11,

        [Description("Ticket collection and examination point")]
        KC = 1 << 12,

        [Description("Ticket examination point")]
        KE = 1 << 13,

        [Description("Ticket examination point, first class only")]
        KF = 1 << 14,

        [Description("Selective ticket examination point")]
        KS = 1 << 15,

        [Description("Stops to change locomotives")]
        L = 1 << 16,

        [Description("Stop not advertised")]
        N = 1 << 17,

        [Description("Stops for other operating reasons")]
        OP = 1 << 18,

        [Description("Train locomotive on rear")]
        OR = 1 << 19,

        [Description("Propelling between points shown")]
        PR = 1 << 20,

        [Description("Stops when required")]
        R = 1 << 21,

        [Description("Reversing movement, or driver changes ends")]
        RM = 1 << 22,

        [Description("Stops for locomotive to run around train")]
        RR = 1 << 23,

        [Description("Stops for railway personnel only")]
        S = 1 << 24,

        [Description("Stops to take up and set down passengers")]
        T = 1 << 25,

        [Description("Stops to attach and detach vehicles")]
        MinusT = 1 << 26,

        [Description("Train begins (Origin)")]
        TB = 1 << 27,

        [Description("Train finishes (Destination")]
        TF = 1 << 28,

        [Description("Detail Consist for TOPS Direct")]
        TS = 1 << 29,

        [Description("Stops (or at pass) for tablet, staff or token")]
        TW = 1 << 30,

        [Description("Stops to take up passengers")]
        U = 1 << 31,

        [Description("Stops to attach vehicles")]
        MinusU = 1 << 32,

        [Description("Stops for watering of coaches")]
        W = 1 << 33,

        [Description("Passes another train at crossing point on single line")]
        X = 1 << 34
    }
}