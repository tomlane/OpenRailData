using OpenRailData.Domain.DarwinSchedule;
using System.Xml.Serialization;

namespace OpenRailData.Darwin.DeserializedXmlObjects
{
    internal interface IDeserializedDarwinJourneyPoint
    {
        DarwinSchedulePointType PointType { get; }

        string TiplocCode { get; set; }
        string Platform { get; set; }
        string LocationActivity { get; set; }
        string PublicArrivalTime { get; set; }
        string PublicDepartureTime { get; set; }
        string WorkingArrivalTime { get; set; }
        string WorkingDepartureTime { get; set; }
        string WorkingPassingTime { get; set; }
    }

    internal abstract class DeserializedDarwinJourneyPoint
    {
        [XmlAttribute("tpl")]
        public string TiplocCode { get; set; }
        [XmlAttribute("plat")]
        public string Platform { get; set; }
        [XmlAttribute("act")]
        public string LocationActivity { get; set; }
        [XmlAttribute("pta")]
        public string PublicArrivalTime { get; set; }
        [XmlAttribute("ptd")]
        public string PublicDepartureTime { get; set; }
        [XmlAttribute("wta")]
        public string WorkingArrivalTime { get; set; }
        [XmlAttribute("wtd")]
        public string WorkingDepartureTime { get; set; }
        [XmlAttribute("wtp")]
        public string WorkingPassingTime { get; set; }
    }

    internal class PublicOriginDarwinSchedulePoint : DeserializedDarwinJourneyPoint, IDeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; } = DarwinSchedulePointType.OR;
    }

    internal class OperationalOriginDarwinSchedulePoint : DeserializedDarwinJourneyPoint, IDeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; } = DarwinSchedulePointType.OPOR;
    }

    internal class IntermediateDarwinSchedulePoint : DeserializedDarwinJourneyPoint, IDeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; } = DarwinSchedulePointType.IP;
    }

    internal class PassingDarwinSchedulePoint : DeserializedDarwinJourneyPoint, IDeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; } = DarwinSchedulePointType.PP;
    }

    internal class OperationalStopDarwinSchedulePoint : DeserializedDarwinJourneyPoint, IDeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; } = DarwinSchedulePointType.OPIP;
    }

    internal class PublicDestinationDarwinSchedulePoint : DeserializedDarwinJourneyPoint, IDeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; } = DarwinSchedulePointType.DT;
    }

    internal class OperationalDestinationDarwinSchedulePoint : DeserializedDarwinJourneyPoint, IDeserializedDarwinJourneyPoint
    {
        public DarwinSchedulePointType PointType { get; } = DarwinSchedulePointType.OPDT;
    }
}