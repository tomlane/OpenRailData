using System.Xml.Serialization;
using OpenRailData.Domain.DarwinSchedule;

namespace OpenRailData.Darwin.ScheduleDeserialization
{
    public abstract class DeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; set; }
    }

    public class PublicOriginDarwinSchedulePoint : DeserializedDarwinJourneyPoint
    {
        public PublicOriginDarwinSchedulePoint()
        {
            PointType = DarwinSchedulePointType.OR;
        }

        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("act")]
        public string LocationActivity { get; set; }
        [XmlAttribute("plat")]
        public string Platform { get; set; }
        
        [XmlAttribute("ptd")]
        public string PublicDepartureTime { get; set; }
        [XmlAttribute("wtd")]
        public string WorkingDepartureTime { get; set; }
    }

    public class OperationalOriginDarwinSchedulePoint : DeserializedDarwinJourneyPoint
    {
        public OperationalOriginDarwinSchedulePoint()
        {
            PointType = DarwinSchedulePointType.OPOR;
        }

        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("act")]
        public string LocationActivity { get; set; }
        [XmlAttribute("plat")]
        public string Platform { get; set; }
        [XmlAttribute("wtd")]
        public string WorkingDepartureTime { get; set; }
    }

    public class IntermediateDarwinSchedulePoint : DeserializedDarwinJourneyPoint
    {
        public IntermediateDarwinSchedulePoint()
        {
            PointType = DarwinSchedulePointType.IP;
        }

        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("pta")]
        public string PublicArrivalTime { get; set; }
        [XmlAttribute("ptd")]
        public string PublicDepartureTime { get; set; }
        [XmlAttribute("wta")]
        public string WorkingArrivalTime { get; set; }
        [XmlAttribute("wtd")]
        public string WorkingDepartureTime { get; set; }
    }

    public class PassingDarwinSchedulePoint : DeserializedDarwinJourneyPoint
    {
        public PassingDarwinSchedulePoint()
        {
            PointType = DarwinSchedulePointType.PP;
        }

        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("wtp")]
        public string WorkingPassingTime { get; set; }

    }

    public class OperationalStopDarwinSchedulePoint : DeserializedDarwinJourneyPoint
    {
        public OperationalStopDarwinSchedulePoint()
        {
            PointType = DarwinSchedulePointType.OPIP;
        }

        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("plat")]
        public string Platform { get; set; }
        [XmlAttribute("act")]
        public string LocationActivity { get; set; }
        [XmlAttribute("wta")]
        public string WorkingArrivalTime { get; set; }
        [XmlAttribute("wtd")]
        public string WorkingDepartureTime { get; set; }
    }

    public class PublicDestinationDarwinSchedulePoint : DeserializedDarwinJourneyPoint
    {
        public PublicDestinationDarwinSchedulePoint()
        {
            PointType = DarwinSchedulePointType.DT;
        }

        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("plat")]
        public string Platform { get; set; }
        [XmlAttribute("act")]
        public string LocationActivity { get; set; }
        [XmlAttribute("pta")]
        public string PublicArrivalTime { get; set; }
        [XmlAttribute("wta")]
        public string WorkingArrivalTime { get; set; }
    }

    public class OperationalDestinationDarwinSchedulePoint : DeserializedDarwinJourneyPoint
    {
        public OperationalDestinationDarwinSchedulePoint()
        {
            PointType = DarwinSchedulePointType.OPDT;
        }
        
        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("plat")]
        public string Platform { get; set; }
        [XmlAttribute("act")]
        public string LocationActivity { get; set; }
        [XmlAttribute("wta")]
        public string WorkingArrivalTime { get; set; }
    }
}