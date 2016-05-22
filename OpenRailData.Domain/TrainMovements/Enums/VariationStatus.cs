using System.ComponentModel;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum VariationStatus
    {
        [Description("On Time")]
        OnTime,

        [Description("Early")]
        Early,

        [Description("Late")]
        Late,

        [Description("Off Route")]
        OffRoute
    }
}