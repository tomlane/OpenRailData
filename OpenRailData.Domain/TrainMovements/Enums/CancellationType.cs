using System.ComponentModel;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum CancellationType
    {
        [Description("On Call")]
        OnCall,

        [Description("At Origin")]
        AtOrigin,

        [Description("En Route")]
        EnRoute,

        [Description("Out of Plan")]
        OutOfPlan
    }
}