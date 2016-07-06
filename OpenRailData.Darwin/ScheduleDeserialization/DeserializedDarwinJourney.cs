using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenRailData.Darwin.ScheduleDeserialization
{
    public class DeserializedDarwinJourney
    {
        [XmlAttribute("rid")]
        public string Rid { get; set; }
        [XmlAttribute("uid")]
        public string Uid { get; set; }
        [XmlAttribute("trainId")]
        public string TrainId { get; set; }
        [XmlAttribute("ssd")]
        public string ScheduleStartDate { get; set; }
        [XmlAttribute("toc")]
        public string TrainOperatingCompany { get; set; }
        [XmlAttribute("trainCat")]
        public string TrainCategory { get; set; }
        [XmlAttribute("status")]
        public string TrainStatus { get; set; }
        [XmlAttribute("isPassengerSvc")]
        public bool PassengerService { get; set; }
        
        [XmlElement("OR", typeof(PublicOriginDarwinSchedulePoint))]
        [XmlElement("OPOR", typeof(OperationalOriginDarwinSchedulePoint))]
        [XmlElement("IP", typeof(IntermediateDarwinSchedulePoint))]
        [XmlElement("PP", typeof(PassingDarwinSchedulePoint))]
        [XmlElement("OPIP", typeof(OperationalStopDarwinSchedulePoint))]
        [XmlElement("DT", typeof(PublicDestinationDarwinSchedulePoint))]
        [XmlElement("OPDT", typeof(OperationalDestinationDarwinSchedulePoint))]
        public List<DeserializedDarwinJourneyPoint> DeserializedDarwinJourneyPoints { get; set; }
    }
}