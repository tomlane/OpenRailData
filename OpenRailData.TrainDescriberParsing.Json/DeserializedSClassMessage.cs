using Newtonsoft.Json;

namespace OpenRailData.TrainDescriberParsing.Json
{
    internal class DeserializedSClassMessage
    {
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("area_id")]
        public string AreaId { get; set; }
        [JsonProperty("msg_type")]
        public string MessageType { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}