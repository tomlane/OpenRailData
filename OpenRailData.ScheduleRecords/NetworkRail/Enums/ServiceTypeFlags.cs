﻿using System;

namespace OpenRailData.ScheduleRecords.NetworkRail.Enums
{
    [Flags]
    public enum ServiceTypeFlags
    {
        Passenger = 1 << 0,
        Train = 1 << 1,
        Bus = 1 << 2,
        Ship = 1 << 3
    }
}