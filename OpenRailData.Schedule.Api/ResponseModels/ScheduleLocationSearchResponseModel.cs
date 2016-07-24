namespace OpenRailData.Schedule.Api.ResponseModels
{
    public class ScheduleLocationSearchResponseModel
    {
        public string Tiploc { get; set; }
        public string OrderTime { get; set; }
        public string Platform { get; set; }
        public string Path { get; set; }
        public string PublicArrival { get; set; }
        public string WorkingArrival { get; set; }
        public string Line { get; set; }
        public string PublicDeparture { get; set; }
        public string WorkingDeparture { get; set; }
        public string Pass { get; set; }
        public string EngineeringAllowance { get; set; }
        public string PathingAllowance { get; set; }
        public string PerformanceAllowance { get; set; }
    }
}