namespace OpenRailData.Schedule.Api.ResponseModels
{
    public class TiplocRecordResponseModel
    {
        /// <summary>
        /// The Tiploc crs code.
        /// </summary>
        public string CrsCode { get; set; }
        /// <summary>
        /// The Tiploc code.
        /// </summary>
        public string TiplocCode { get; set; }
        /// <summary>
        /// The location name of the Tiploc.
        /// </summary>
        public string LocationName { get; set; }
    }
}