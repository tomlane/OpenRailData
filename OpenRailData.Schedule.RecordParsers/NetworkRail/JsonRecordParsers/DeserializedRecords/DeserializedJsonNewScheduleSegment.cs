using Newtonsoft.Json;

namespace OpenRailData.Schedule.RecordParsers.NetworkRail.JsonRecordParsers.DeserializedRecords
{
    public class DeserializedJsonNewScheduleSegment
    {
        [JsonProperty("traction_class")]
        public string TractionClass { get; set; }

        [JsonProperty("uic_code")]
        public string UicCode { get; set; }
    }
}