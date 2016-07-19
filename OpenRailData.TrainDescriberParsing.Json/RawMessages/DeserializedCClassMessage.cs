using Newtonsoft.Json;

namespace OpenRailData.TrainDescriberParsing.Json.RawMessages
{
    internal class DeserializedCClassMessage
    {
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("area_id")]
        public string AreaId { get; set; }
        [JsonProperty("msg_type")]
        public string MessageType { get; set; }
        [JsonProperty("from")]
        public string FromBerth { get; set; }
        [JsonProperty("to")]
        public string ToBerth { get; set; }
        [JsonProperty("descr")]
        public string TrainDescription { get; set; }
        [JsonProperty("report_time")]
        public string ReportTime { get; set; }
    }
}