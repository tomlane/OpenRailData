using System;

namespace NetworkRail.CifParser.Records.Enums
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