using System;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    [Flags]
    public enum ServiceTypeFlags
    {
        /// <summary>
        /// Passenger.
        /// </summary>
        Passenger = 1 << 0,
        /// <summary>
        /// Train.
        /// </summary>
        Train = 1 << 1,
        /// <summary>
        /// Bus.
        /// </summary>
        Bus = 1 << 2,
        /// <summary>
        /// Ship.
        /// </summary>
        Ship = 1 << 3
    }
}