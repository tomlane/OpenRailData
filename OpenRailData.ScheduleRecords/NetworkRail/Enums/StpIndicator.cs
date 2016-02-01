﻿using System.ComponentModel;

namespace OpenRailData.ScheduleRecords.NetworkRail.Enums
{
    public enum StpIndicator
    {
        [Description("Permanent Schedule")]
        P = 1,
        
        [Description("Overlay Schedule")]
        O = 2,

        [Description("New Schedule")]
        N = 3,

        [Description("Schedule Cancellation")]
        C = 4
    }
}