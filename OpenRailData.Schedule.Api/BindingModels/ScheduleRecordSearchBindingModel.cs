using System;
using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Api.BindingModels
{
    /// <summary>
    /// The schedule record search model for searching by TrainUid and schedule start date.
    /// </summary>
    public class ScheduleRecordSearchBindingModel
    {
        /// <summary>
        /// The TrainUid.
        /// </summary>
        [Required]
        public string TrainUid { get; set; }
        /// <summary>
        /// The schedule start date.
        /// </summary>
        [Required]
        public DateTime ScheduleStartDate { get; set; }
    }
}