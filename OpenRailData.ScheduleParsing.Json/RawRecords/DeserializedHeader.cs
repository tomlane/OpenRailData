using Newtonsoft.Json;

namespace OpenRailData.ScheduleParsing.Json.RawRecords
{
    internal class DeserializedHeader
    {
        [JsonProperty("JsonTimetableV1")]
        public JsonHeader Header { get; set; }
    }

    internal class JsonHeader
    {
        [JsonProperty("classification")]
        public string Classification { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("Sender")]
        internal Sender Sender { get; set; }
        [JsonProperty("Metadata")]
        internal MetaData MetaData { get; set; }
    }

    internal class MetaData
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("sequence")]
        public string Sequence { get; set; }
    }

    internal class Sender
    {
        [JsonProperty("organisation")]
        public string Organisation { get; set; }
        [JsonProperty("application")]
        public string Application { get; set; }
        [JsonProperty("component")]
        public string Component { get; set; }
    }
}