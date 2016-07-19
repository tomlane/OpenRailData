namespace OpenRailData.Darwin.Entites.Schedule
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
        /// Working arrival time of the associated journey.
        /// </summary>
        public string AssocWorkingArrivalTime { get; set; }
        /// <summary>
        /// Working departure time of the associated journey.
        /// </summary>
        public string AssocWorkingDepartureTime { get; set; }
        /// <summary>
        /// Public arrival time of the associated journey.
        /// </summary>
        public string AssocPublicArrivalTime { get; set; }
        /// <summary>
        /// Public departure time of the associated journey. 
        /// </summary>
        public string AssocPublicDepartureTime { get; set; }
        /// <summary>
        /// The association category.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// The tiploc code of the location where the association applies.
        /// </summary>
        public string TiplocCode { get; set; }
    }
}