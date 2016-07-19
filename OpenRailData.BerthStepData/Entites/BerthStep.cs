namespace OpenRailData.BerthStepData.Entites
{
    public class BerthStep
    {
        /// <summary>
        ///     Train Describer area.
        /// </summary>
        public string TrainDescriber { get; set; }
        /// <summary>
        ///     Berth that the movement is from.
        /// </summary>
        public string FromBerth { get; set; }
        /// <summary>
        ///     Berth that the movement is to.
        /// </summary>
        public string ToBerth { get; set; }
        /// <summary>
        ///     Line which the movement is from.
        /// </summary>
        public string FromLine { get; set; }
        /// <summary>
        ///     Line which the movement is to.
        /// </summary>
        public string ToLine { get; set; }
        /// <summary>
        ///     Difference between the time the berth event occurs and the time to be recorded in TRUST, in seconds.
        /// </summary>
        public long BerthOffset { get; set; }
        /// <summary>
        ///     Platform.
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        ///     Berth event type.
        /// </summary>
        public BerthEvent BerthEvent { get; set; }
        /// <summary>
        ///     Route.
        /// </summary>
        public string Route { get; set; }
        /// <summary>
        ///     Stanox code for the location.
        /// </summary>
        public string Stanox { get; set; }
        /// <summary>
        ///     Abbreviated description of the location.
        /// </summary>
        public string Stanme { get; set; }
        /// <summary>
        ///     Berth step type.
        /// </summary>
        public BerthStepType BerthStepType { get; set; }
        /// <summary>
        ///     Comment notes.
        /// </summary>
        public string Comment { get; set; } 
    }
}