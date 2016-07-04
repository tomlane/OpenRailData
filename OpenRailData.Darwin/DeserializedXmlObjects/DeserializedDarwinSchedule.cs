﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenRailData.Darwin.DeserializedXmlObjects
{
    [XmlRoot("PportTimetable", Namespace = "http://www.thalesgroup.com/rtti/XmlTimetable/v8")]
    internal class DeserializedDarwinSchedule
    {
        [XmlAttribute("timetableID")]
        public string TimetableId { get; set; }
        [XmlElement("Journey")]
        public List<DeserializedDarwinJourney> DeserializedDarwinJourneys { get; set; }
        [XmlElement("Association")]
        public List<DeserializedDarwinAssociation> DeserializedDarwinAssociations { get; set; }
    }
}