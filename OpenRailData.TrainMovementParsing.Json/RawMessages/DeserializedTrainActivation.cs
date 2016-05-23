using Newtonsoft.Json;

namespace OpenRailData.TrainMovementParsing.Json.RawMessages
{
    internal class DeserializedJsonTrainActivation
    {
        [JsonProperty("header")]
        public DeserializedJsonActivationHeader Header { get; set; }

        [JsonProperty("body")]
        public DeserializedJsonActivationBody Body { get; set; }
    }

    internal class DeserializedJsonActivationHeader
    {
        [JsonProperty("source_dev_id")]
        public string SourceDeviceId { get; set; }

        [JsonProperty("source_system_id")]
        public string SourceSystemId { get; set; }

        [JsonProperty("original_data_source")]
        public string OriginalDataSource { get; set; }
    }

    internal class DeserializedJsonActivationBody
    {
        [JsonProperty("train_id")]
        public string TrainId { get; set; }

        [JsonProperty("creation_timestamp")]
        public string CreationTimestamp { get; set; }

        [JsonProperty("tp_origin_timestamp")]
        public string OriginTimeStamp { get; set; }

        [JsonProperty("train_uid")]
        public string TrainUid { get; set; }

        [JsonProperty("sched_origin_stanox")]
        public string ScheduleOriginStanox { get; set; }

        [JsonProperty("schedule_start_date")]
        public string ScheduleStartDate { get; set; }

        [JsonProperty("schedule_end_date")]
        public string ScheduleEndDate { get; set; }

        [JsonProperty("schedule_source")]
        public string ScheduleSource { get; set; }

        [JsonProperty("schedule_type")]
        public string ScheduleType { get; set; }

        [JsonProperty("schedule_wtt_id")]
        public string ScheduleWttId { get; set; }

        [JsonProperty("d1266_record_number")]
        public string DRecordNumber { get; set; }

        [JsonProperty("tp_origin_stanox")]
        public string OriginStanox { get; set; }

        [JsonProperty("origin_dep_timestamp")]
        public string OriginDepartureTimestamp { get; set; }

        [JsonProperty("train_call_type")]
        public string TrainCallType { get; set; }

        [JsonProperty("train_call_mode")]
        public string TrainCallMode { get; set; }

        [JsonProperty("toc_id")]
        public string TocId { get; set; }

        [JsonProperty("train_service_code")]
        public string TrainServiceCode { get; set; }

        [JsonProperty("train_file_address")]
        public string TrainFileAddress { get; set; }
    }
}