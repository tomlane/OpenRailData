using Newtonsoft.Json;

namespace OpenRailData.ScheduleParsing.Json.RawRecords
{
    internal class DeserializedAssociation
    {
        [JsonProperty("JsonAssociationV1")]
        public Association Association { get; set; }
    }

    internal class Association
    {
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
        [JsonProperty("main_train_uid")]
        public string MainTrainUid { get; set; }
        [JsonProperty("assoc_train_uid")]
        public string AssocTrainUid { get; set; }
        [JsonProperty("assoc_end_date")]
        public string AssocEndDate { get; set; }
        [JsonProperty("assoc_start_date")]
        public string AssocStartDate { get; set; }
        [JsonProperty("assoc_days")]
        public string AssocDays { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("date_indicator")]
        public string DateIndicator { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("base_location_suffix")]
        public string BaseLocationSuffix { get; set; }
        [JsonProperty("assoc_location_suffix")]
        public string AssocLocationSuffix { get; set; }
        [JsonProperty("diagram_type`")]
        public string DiagramType { get; set; }
        [JsonProperty("CIF_stp_indicator")]
        public string StpIndicator { get; set; }
    }
}