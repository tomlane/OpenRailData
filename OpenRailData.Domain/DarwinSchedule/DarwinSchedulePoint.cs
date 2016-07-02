namespace OpenRailData.Domain.DarwinSchedule
{
    public class DarwinSchedulePoint
    {
        /// <summary>
        /// The type of schedule point.
        /// </summary>
        /// <remarks>Can be either: origin, intermediate, operational stop, passing, destination.</remarks>
        public DarwinSchedulePointType PointType { get; set; }
        /// <summary>
        /// The TIPLOC code of the point location.
        /// </summary>
        public string Tiploc { get; set; }
        /// <summary>
        /// Operational activities that get performed at this point.
        /// </summary>
        public string LocationActivity { get; set; }
        /// <summary>
        /// Arrival time from the public timetable.
        /// </summary>
        public string PublicArrivalTime { get; set; }
        /// <summary>
        /// Arrival time from the working timetable.
        /// </summary>
        public string WorkingArrivalTime { get; set; }
        /// <summary>
        /// Working passing time.
        /// </summary>
        public string WorkingPassTime { get; set; }
        /// <summary>
        /// Departure time from the public timetable.
        /// </summary>
        public string PublicDepartureTime { get; set; }
        /// <summary>
        /// Departure time from the working timetable.
        /// </summary>
        public string WorkingDepartureTime { get; set; }
        /// <summary>
        /// Platform for the point, if applicable.
        /// </summary>
        public string Platform { get; set; }
    }
}