using System;
using System.Collections.Generic;

namespace OpenRailData.Domain.DarwinSchedule
{
    public class DarwinScheduleJourney
    {
        /// <summary>
        /// The unique identifier for the journey.
        /// </summary>
        public string Rid { get; set; }
        /// <summary>
        /// The train UID from the schedule.
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// The train ID (4 character headcode).
        /// </summary>
        public string TrainId { get; set; }
        /// <summary>
        /// The start date of the schedule.
        /// </summary>
        public DateTime ScheduleStartDate { get; set; }
        /// <summary>
        /// The identifying code for the TOC of this journey.
        /// </summary>
        public string Toc { get; set; }
        /// <summary>
        /// Train category. 
        /// </summary>
        public string TrainCategory { get; set; }
        /// <summary>
        /// Indicates whether the journey is a passenger service.
        /// </summary>
        public bool IsPassengerService { get; set; }
        /// <summary>
        /// The status code of the train.
        /// </summary>
        public string TrainStatus { get; set; }
        /// <summary>
        /// A list of points in the schedule.
        /// </summary>
        /// <remarks>Typically contains an origin and destination point, along with intermediate passenger points, operational stops and passes.</remarks>
        public List<DarwinSchedulePoint> SchedulePoints { get; set; }
        /// <summary>
        /// The reason code if the journey has been cancelled.
        /// </summary>
        public string CancellationReason { get; set; }
    }
}