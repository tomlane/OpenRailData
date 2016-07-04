using System.Xml.Serialization;

namespace OpenRailData.Darwin.DeserializedXmlObjects
{
    internal class DeserializedDarwinAssociation
    {
        [XmlAttribute("tiploc")]
        public string TiplocCode { get; set; }
        [XmlAttribute("category")]
        public string Category { get; set; }
        [XmlElement("main")]
        public DeserializedDarwinAssociationPortion Main { get; set; }
        [XmlElement("assoc")]
        public DeserializedDarwinAssociationPortion Assoc { get; set; }
    }

    internal class DeserializedDarwinAssociationPortion
    {
        [XmlAttribute("rid")]
        public string Rid { get; set; }
        [XmlAttribute("pta")]
        public string PublicArrivalTime { get; set; }
        [XmlAttribute("ptd")]
        public string PublicDepartureTime { get; set; }
        [XmlAttribute("wta")]
        public string WorkingArrivalTime { get; set; }
        [XmlAttribute("wtd")]
        public string WorkingDepartureTime { get; set; }
    }
}