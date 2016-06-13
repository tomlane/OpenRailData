using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenRailData.ScheduleParsing.Json.RawRecords
{
    internal class DeserializedRecord
    {
        [JsonProperty("JsonScheduleV1")]
        public JsonSchedule Schedule { get; set; }
    }

    internal class JsonSchedule
    {
        [JsonProperty("CIF_train_uid")]
        public string TrainUid { get; set; }
        [JsonProperty("CIF_bank_holiday_running")]
        public string BankHolidayRunning { get; set; }
        [JsonProperty("CIF_stp_indicator")]
        public string StpIndicator { get; set; }
        [JsonProperty("applicable_timetable")]
        public string ApplicableTimetable { get; set; }
        [JsonProperty("atoc_code")]
        public string AtocCode { get; set; }
        [JsonProperty("new_schedule_segment")]
        public NewScheduleSegment NewScheduleSegment { get; set; }
        [JsonProperty("schedule_days_runs")]
        public string DaysRuns { get; set; }
        [JsonProperty("schedule_end_date")]
        public string ScheduleEndDate { get; set; }
        [JsonProperty("schedule_segment")]
        public ScheduleSegment ScheduleSegment { get; set; }
        [JsonProperty("schedule_start_date")]
        public string ScheduleStartDate { get; set; }
        [JsonProperty("train_status")]
        public string TrainStatus { get; set; }
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
    }

    internal class NewScheduleSegment
    {
        [JsonProperty("traction_class")]
        public string TractionClass { get; set; }
        [JsonProperty("uic_code")]
        public string UicCode { get; set; }
    }
    
    internal class ScheduleSegment
    {
        [JsonProperty("signalling_id")]
        public string SignallingId { get; set; }
        [JsonProperty("CIF_train_category")]
        public string TrainCategory { get; set; }
        [JsonProperty("CIF_headcode")]
        public string HeadCode { get; set; }
        [JsonProperty("CIF_course_indicator")]
        public string CourseIndicator { get; set; }
        [JsonProperty("CIF_train_service_code")]
        public string TrainServiceCode { get; set; }
        [JsonProperty("CIF_business_sector")]
        public string BusinessSector { get; set; }
        [JsonProperty("CIF_power_type")]
        public string PowerType { get; set; }
        [JsonProperty("CIF_timing_load")]
        public string TimingLoad { get; set; }
        [JsonProperty("CIF_speed")]
        public string Speed { get; set; }
        [JsonProperty("CIF_operating_characteristics")]
        public string OperatingCharacteristics { get; set; }
        [JsonProperty("CIF_train_class")]
        public string TrainClass { get; set; }
        [JsonProperty("CIF_sleepers")]
        public string Sleepers { get; set; }
        [JsonProperty("CIF_reservations")]
        public string Reservations { get; set; }
        [JsonProperty("CIF_connection_indicator")]
        public string ConnectionIndicator { get; set; }
        [JsonProperty("CIF_catering_code")]
        public string CateringCode { get; set; }
        [JsonProperty("CIF_service_branding")]
        public string ServiceBranding { get; set; }
        [JsonProperty("schedule_location")]
        public IList<ScheduleLocation> ScheduleLocations { get; set; }
    }

    internal class ScheduleLocation
    {
        [JsonProperty("location_type")]
        public string LocationType { get; set; }
        [JsonProperty("record_identity")]
        public string RecordIdentity { get; set; }
        [JsonProperty("tiploc_code")]
        public string TiplocCode { get; set; }
        [JsonProperty("tiploc_instance")]
        public string TiplocInstance { get; set; }
        [JsonProperty("departure")]
        public string WorkingDeparture { get; set; }
        [JsonProperty("arrival")]
        public string WorkingArrival { get; set; }
        [JsonProperty("public_departure")]
        public string PublicDeparture { get; set; }
        [JsonProperty("public_arrival")]
        public string PublicArrival { get; set; }
        [JsonProperty("platform")]
        public string Platform { get; set; }
        [JsonProperty("line")]
        public string Line { get; set; }
        [JsonProperty("engineering_allowance")]
        public string EngineeringAllowance { get; set; }
        [JsonProperty("pathing_allowance")]
        public string PathingAllowance { get; set; }
        [JsonProperty("performance_allowance")]
        public string PerformanceAllowance { get; set; }
        [JsonProperty("pass")]
        public string Pass { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}