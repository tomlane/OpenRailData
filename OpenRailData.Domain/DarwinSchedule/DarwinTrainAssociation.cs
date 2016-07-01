namespace OpenRailData.Domain.DarwinSchedule
{
    public class DarwinTrainAssociation
    {
        public string MainRid { get; set; }
        public string MainWorkingArrivalTime { get; set; }
        public string MainPublicArrivalTime { get; set; }

        public string AssocRid { get; set; }
        public string AssocWorkingDepartureTime { get; set; }
        public string AssocPublicDepartureTime { get; set; }
    }
}