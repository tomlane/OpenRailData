﻿using System.ComponentModel;

namespace OpenRailData.Schedule.Records.NetworkRail.Enums
{
    public enum AssociationCategory
    {
        [Description("None")]
        None = 0,

        [Description("Join")]
        JJ = 1,

        [Description("Split")]
        VV = 2,

        [Description("Next")]
        NP = 3
    }
}