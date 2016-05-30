using Newtonsoft.Json;

namespace OpenRailData.ScheduleParsing.Json.RawRecords
{
    internal class DeserializedTiploc
    {
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
        [JsonProperty("tiploc_code")]
        public string TiplocCode { get; set; }
        [JsonProperty("nalco")]
        public string Nalco { get; set; }
        [JsonProperty("stanox")]
        public string Stanox { get; set; }
        [JsonProperty("crs_code")]
        public string CrsCode { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("tps_description")]
        public string TpsDescription { get; set; }
    }
}