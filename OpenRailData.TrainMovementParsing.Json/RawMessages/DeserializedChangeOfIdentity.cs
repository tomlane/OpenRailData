using Newtonsoft.Json;

namespace OpenRailData.TrainMovementParsing.Json.RawMessages
{
    internal class DeserializedChangeOfIdentity
    {
        [JsonProperty("header")]
        public DeserializedChangeOfIdentityHeader Header { get; set; }

        [JsonProperty("body")]
        public DeserializedChangeOfIdentityBody Body { get; set; }
    }

    internal class DeserializedChangeOfIdentityHeader
    {
        [JsonProperty("source_dev_id")]
        public string SourceDeviceId { get; set; }

        [JsonProperty("source_system_id")]
        public string SourceSystemId { get; set; }

        [JsonProperty("original_data_source")]
        public string OriginalDataSource { get; set; }
    }

    internal class DeserializedChangeOfIdentityBody
    {
        [JsonProperty("train_id")]
        public string TrainId { get; set; }

        [JsonProperty("current_train_id")]
        public string CurrentTrainId { get; set; }

        [JsonProperty("revised_train_id")]
        public string RevisedTrainId { get; set; }

        [JsonProperty("train_file_address")]
        public string TrainFileAddress { get; set; }

        [JsonProperty("train_service_code")]
        public string TrainServiceCode { get; set; }

        [JsonProperty("event_timestamp")]
        public string EventTimestamp { get; set; }
    }
}