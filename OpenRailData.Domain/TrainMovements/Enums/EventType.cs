using System.ComponentModel;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum EventType
    {
        [Description("Arrival")]
        Arrival,

        [Description("Departure")]
        Departure,

        [Description("Destination")]
        Destination
    }
}