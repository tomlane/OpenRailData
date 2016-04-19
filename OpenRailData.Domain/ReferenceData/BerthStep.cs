namespace OpenRailData.Domain.ReferenceData
{
    public class BerthStep
    {
        public string TrainDescriber { get; set; }
        public string FromBerth { get; set; }
        public string ToBerth { get; set; }
        public string FromLine { get; set; }
        public string ToLine { get; set; }
        public long BerthOffset { get; set; }
        public string Platform { get; set; }
        public BerthEvent BerthEvent { get; set; }
        public string Route { get; set; }
        public string Stanox { get; set; }
        public string Stanme { get; set; }
        public BerthStepType BerthStepType { get; set; }
        public string Comment { get; set; } 
    }
}