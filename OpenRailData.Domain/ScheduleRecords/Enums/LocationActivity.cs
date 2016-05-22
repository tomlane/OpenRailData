using System;
using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    [Flags]
    public enum LocationActivity
    {
        [Display(Name = "Stops or shunts for other trains to pass")]
        A = 1 << 0,

        [Display(Name = "Attach/detach assisting locomotive")]
        AE = 1 << 1,

        [Display(Name = "Shows as 'X' on arrival")]
        AX = 1 << 2,

        [Display(Name = "Stops for banking locomotive")]
        BL = 1 << 3,

        [Display(Name = "Stops to change trainmen")]
        C = 1 << 4,

        [Display(Name = "Stops to set down passengers")]
        D = 1 << 5,

        [Display(Name = "Stops to detach vehicles")]
        MinusD = 1 << 6,

        [Display(Name = "Stops for examination")]
        E = 1 << 7,

        [Display(Name = "National Rail Timetable data to add")]
        G = 1 << 8,

        [Display(Name = "Notional activity to prevent WTT timing columns merge")]
        H = 1 << 9,

        [Display(Name = "Notional activity to prevent WTT timing columns merge, with third column")]
        HH = 1 << 10,

        [Display(Name = "Passenger count point")]
        K = 1 << 11,

        [Display(Name = "Ticket collection and examination point")]
        KC = 1 << 12,

        [Display(Name = "Ticket examination point")]
        KE = 1 << 13,

        [Display(Name = "Ticket examination point, first class only")]
        KF = 1 << 14,

        [Display(Name = "Selective ticket examination point")]
        KS = 1 << 15,

        [Display(Name = "Stops to change locomotives")]
        L = 1 << 16,

        [Display(Name = "Stop not advertised")]
        N = 1 << 17,

        [Display(Name = "Stops for other operating reasons")]
        OP = 1 << 18,

        [Display(Name = "Train locomotive on rear")]
        OR = 1 << 19,

        [Display(Name = "Propelling between points shown")]
        PR = 1 << 20,

        [Display(Name = "Stops when required")]
        R = 1 << 21,

        [Display(Name = "Reversing movement, or driver changes ends")]
        RM = 1 << 22,

        [Display(Name = "Stops for locomotive to run around train")]
        RR = 1 << 23,

        [Display(Name = "Stops for railway personnel only")]
        S = 1 << 24,

        [Display(Name = "Stops to take up and set down passengers")]
        T = 1 << 25,

        [Display(Name = "Stops to attach and detach vehicles")]
        MinusT = 1 << 26,

        [Display(Name = "Train begins (Origin)")]
        TB = 1 << 27,

        [Display(Name = "Train finishes (Destination")]
        TF = 1 << 28,

        [Display(Name = "Detail Consist for TOPS Direct")]
        TS = 1 << 29,

        [Display(Name = "Stops (or at pass) for tablet, staff or token")]
        TW = 1 << 30,

        [Display(Name = "Stops to take up passengers")]
        U = 1 << 31,

        [Display(Name = "Stops to attach vehicles")]
        MinusU = 1 << 32,

        [Display(Name = "Stops for watering of coaches")]
        W = 1 << 33,

        [Display(Name = "Passes another train at crossing point on single line")]
        X = 1 << 34
    }
}