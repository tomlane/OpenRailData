using Newtonsoft.Json;

namespace OpenRailData.TrainMovementParsing.Json.RawMessages
{
    internal class DeserializedChangeOfOrigin
    {
        [JsonProperty("header")]
        public DeserializedChangeOfOriginHeader Header { get; set; }

        [JsonProperty("body")]
        public DeserializedChangeOfOriginBody Body { get; set; }
    }

    internal class DeserializedChangeOfOriginHeader
    {
        [JsonProperty("source_dev_id")]
        public string SourceDeviceId { get; set; }

        [JsonProperty("source_system_id")]
        public string SourceSystemId { get; set; }

        [JsonProperty("original_data_source")]
        public string OriginalDataSource { get; set; }
    }

    internal class DeserializedChangeOfOriginBody
    {
        [JsonProperty("train_id")]
        public string TrainId { get; set; }
        [JsonProperty("dep_timestamp")]
        public string DepartureTimestamp { get; set; }
        [JsonProperty("loc_stanox")]
        public string LocationStanox { get; set; }
        [JsonProperty("original_loc_stanox")]
        public string OriginalLocationStanox { get; set; }
        [JsonProperty("original_loc_timestamp")]
        public string OriginalLocationTimestamp { get; set; }
        [JsonProperty("current_train_id")]
        public string CurrentTrainId { get; set; }
        [JsonProperty("train_service_code")]
        public string TrainServiceCode { get; set; }
        [JsonProperty("reason_code")]
        public string ReasonCode { get; set; }
        [JsonProperty("division_code")]
        public string DivisionCode { get; set; }
        [JsonProperty("toc_id")]
        public string TocId { get; set; }
        [JsonProperty("train_file_address")]
        public string TrainFileAddress { get; set; }
        [JsonProperty("coo_timestamp")]
        public string ChangeOfOriginTimestamp { get; set; }
    }
}