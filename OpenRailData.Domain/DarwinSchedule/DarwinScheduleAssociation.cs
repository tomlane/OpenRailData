namespace OpenRailData.Domain.DarwinSchedule
{
    public class DarwinScheduleAssociation
    {
        /// <summary>
        /// Rid of the main journey.
        /// </summary>
        public string MainRid { get; set; }
        /// <summary>
        /// Working arrival time of the main journey.
        /// </summary>
        public string MainWorkingArrivalTime { get; set; }
        /// <summary>
        /// Working departure time of the main journey.
        /// </summary>
        public string MainWorkingDepartureTime { get; set; }
        /// <summary>
        /// Public arrival time of the main journey.
        /// </summary>
        /// <remarks>Used when a journey splits.</remarks>
        public string MainPublicArrivalTime { get; set; }
        /// <summary>
        /// Public departure time of the main journey.
        /// </summary>
        /// <remarks>Used when a journey splits.</remarks>
        public string MainPublicDepartureTime { get; set; }
        /// <summary>
        /// Rid of the associated journey.
        /// </summary>
        public string AssocRid { get; set; }
        /// <summary>
        /// Working departure time of the associated journey.
        /// </summary>
        public string AssocWorkingDepartureTime { get; set; }
        /// <summary>
        /// Public departure time of the associated journey. 
        /// </summary>
        public string AssocPublicDepartureTime { get; set; }
    }
}