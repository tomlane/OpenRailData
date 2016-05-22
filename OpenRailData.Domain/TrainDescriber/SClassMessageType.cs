﻿using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainDescriber
{
    public enum SClassMessageType
    {
        [Display(Name = "Signal Update")]
        Update,

        [Display(Name = "Signal Refesh")]
        Refresh,

        [Display(Name = "Signal Refresh Finished")]
        RefreshFinished
    }
}