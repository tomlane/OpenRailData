using System.ComponentModel;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum ScheduleSource
    {
        [Description("CIF")]
        Cif,

        [Description("Very Short Term Plan")]
        Vstp
    }
}