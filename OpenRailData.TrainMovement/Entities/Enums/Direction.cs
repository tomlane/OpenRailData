﻿using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainMovement.Entities.Enums
{
    public enum Direction
    {
        /// <summary>
        /// Up.
        /// </summary>
        [Display(Name = "Up")]
        UP,
        /// <summary>
        /// Down.
        /// </summary>
        [Display(Name = "Down")]
        DOWN,
        /// <summary>
        /// None.
        /// </summary>
        [Display(Name = "None")]
        None
    }
}