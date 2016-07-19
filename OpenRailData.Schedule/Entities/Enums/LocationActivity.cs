using System;
using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities.Enums
{
    [Flags]
    public enum LocationActivity
    {
        /// <summary>
        /// Stops or shunts for other trains to pass.
        /// </summary>
        [Display(Name = "Stops or shunts for other trains to pass")]
        A = 1 << 0,
        /// <summary>
        /// Attach/detach assisting locomotive.
        /// </summary>
        [Display(Name = "Attach/detach assisting locomotive")]
        AE = 1 << 1,
        /// <summary>
        /// Shows as 'X' on arrival.
        /// </summary>
        [Display(Name = "Shows as 'X' on arrival")]
        AX = 1 << 2,
        /// <summary>
        /// Stops for banking locomotive.
        /// </summary>
        [Display(Name = "Stops for banking locomotive")]
        BL = 1 << 3,
        /// <summary>
        /// Stops to change trainmen.
        /// </summary>
        [Display(Name = "Stops to change trainmen")]
        C = 1 << 4,
        /// <summary>
        /// Stops to set down passengers.
        /// </summary>
        [Display(Name = "Stops to set down passengers")]
        D = 1 << 5,
        /// <summary>
        /// Stops to detach vehicles.
        /// </summary>
        [Display(Name = "Stops to detach vehicles")]
        MinusD = 1 << 6,
        /// <summary>
        /// Stops for examination.
        /// </summary>
        [Display(Name = "Stops for examination")]
        E = 1 << 7,
        /// <summary>
        /// National rail timetable data to add.
        /// </summary>
        [Display(Name = "National Rail Timetable data to add")]
        G = 1 << 8,
        /// <summary>
        /// Notional activity to prevent WTT timing columns merge.
        /// </summary>
        [Display(Name = "Notional activity to prevent WTT timing columns merge")]
        H = 1 << 9,
        /// <summary>
        /// Notional activity to prevent WTT timing columns merge, with third column.
        /// </summary>
        [Display(Name = "Notional activity to prevent WTT timing columns merge, with third column")]
        HH = 1 << 10,
        /// <summary>
        /// Passenger count point.
        /// </summary>
        [Display(Name = "Passenger count point")]
        K = 1 << 11,
        /// <summary>
        /// Ticket collection and examination point.
        /// </summary>
        [Display(Name = "Ticket collection and examination point")]
        KC = 1 << 12,
        /// <summary>
        /// Ticket examination point.
        /// </summary>
        [Display(Name = "Ticket examination point")]
        KE = 1 << 13,
        /// <summary>
        /// Ticket examination point, first class only.
        /// </summary>
        [Display(Name = "Ticket examination point, first class only")]
        KF = 1 << 14,
        /// <summary>
        /// Selective ticket examination point.
        /// </summary>
        [Display(Name = "Selective ticket examination point")]
        KS = 1 << 15,
        /// <summary>
        /// Stops to change locomotives.
        /// </summary>
        [Display(Name = "Stops to change locomotives")]
        L = 1 << 16,
        /// <summary>
        /// Stop not advertised.
        /// </summary>
        [Display(Name = "Stop not advertised")]
        N = 1 << 17,
        /// <summary>
        /// Stops for other operating reasons.
        /// </summary>
        [Display(Name = "Stops for other operating reasons")]
        OP = 1 << 18,
        /// <summary>
        /// Train locomotive on rear.
        /// </summary>
        [Display(Name = "Train locomotive on rear")]
        OR = 1 << 19,
        /// <summary>
        /// Propelling between points shown.
        /// </summary>
        [Display(Name = "Propelling between points shown")]
        PR = 1 << 20,
        /// <summary>
        /// Stops when required.
        /// </summary>
        [Display(Name = "Stops when required")]
        R = 1 << 21,
        /// <summary>
        /// Reversing movement, or driver changes ends.
        /// </summary>
        [Display(Name = "Reversing movement, or driver changes ends")]
        RM = 1 << 22,
        /// <summary>
        /// Stops for locomotive to run around train.
        /// </summary>
        [Display(Name = "Stops for locomotive to run around train")]
        RR = 1 << 23,
        /// <summary>
        /// Stops for railway personnel only.
        /// </summary>
        [Display(Name = "Stops for railway personnel only")]
        S = 1 << 24,
        /// <summary>
        /// Stops to take up and set down passengers.
        /// </summary>
        [Display(Name = "Stops to take up and set down passengers")]
        T = 1 << 25,
        /// <summary>
        /// Stops to attach and detach vehicles. 
        /// </summary>
        [Display(Name = "Stops to attach and detach vehicles")]
        MinusT = 1 << 26,
        /// <summary>
        /// Train begins (origin).
        /// </summary>
        [Display(Name = "Train begins (Origin)")]
        TB = 1 << 27,
        /// <summary>
        /// Train finishes (destination).
        /// </summary>
        [Display(Name = "Train finishes (Destination")]
        TF = 1 << 28,
        /// <summary>
        /// Detail consist for TOPS direct.
        /// </summary>
        [Display(Name = "Detail Consist for TOPS Direct")]
        TS = 1 << 29,
        /// <summary>
        /// Stops (or at pass) for tablet, staff, or token.
        /// </summary>
        [Display(Name = "Stops (or at pass) for tablet, staff or token")]
        TW = 1 << 30,
        /// <summary>
        /// Stops to take up passengers. 
        /// </summary>
        [Display(Name = "Stops to take up passengers")]
        U = 1 << 31,
        /// <summary>
        /// Stops to attach vehicles. 
        /// </summary>
        [Display(Name = "Stops to attach vehicles")]
        MinusU = 1 << 32,
        /// <summary>
        /// Stops for watering of coaches.
        /// </summary>
        [Display(Name = "Stops for watering of coaches")]
        W = 1 << 33,
        /// <summary>
        /// Passes another train at crossing point on single line. 
        /// </summary>
        [Display(Name = "Passes another train at crossing point on single line")]
        X = 1 << 34
    }
}