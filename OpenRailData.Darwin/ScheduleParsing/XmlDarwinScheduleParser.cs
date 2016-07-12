using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using OpenRailData.Domain.DarwinSchedule;

namespace OpenRailData.Darwin.ScheduleParsing
{
    public class XmlDarwinScheduleParser : IDarwinScheduleParser
    {
        public DarwinSchedule ParseSchedule(string rawSchedule)
        {
            if (string.IsNullOrWhiteSpace(rawSchedule))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(rawSchedule));

            XDocument timetable = XDocument.Parse(rawSchedule);

            XNamespace scheduleNamespace = "http://www.thalesgroup.com/rtti/XmlTimetable/v8";
            
            var journeys =
                (from journey in timetable.Root.Elements(scheduleNamespace + "Journey")
                 select new DarwinScheduleJourney
                 {
                     Rid = (string)journey.Attribute("rid"),
                     Uid = (string)journey.Attribute("uid"),
                     TrainId = (string)journey.Attribute("trainId"),
                     ScheduleStartDate = (DateTime)journey.Attribute("ssd"),
                     Toc = (string)journey.Attribute("toc"),
                     TrainCategory = (string)journey.Attribute("trainCat") ?? string.Empty,
                     IsPassengerService = bool.Parse((string)journey.Attribute("isPassengerSvc") ?? "true"),
                     TrainStatus = (string)journey.Attribute("trainStatus") ?? string.Empty,
                     SchedulePoints = journey.Descendants().Where(x => x.Name.LocalName.Length == 2).Select(point => new DarwinSchedulePoint
                     {
                         LocationActivity = (string)point.Attribute("act"),
                         Platform = (string)point.Attribute("plat") ?? string.Empty,
                         PointType = (DarwinSchedulePointType)Enum.Parse(typeof(DarwinSchedulePointType), point.Name.LocalName),
                         PublicArrivalTime = (string)point.Attribute("pta") ?? string.Empty,
                         PublicDepartureTime = (string)point.Attribute("ptd") ?? string.Empty,
                         Tiploc = (string)point.Attribute("tpl"),
                         WorkingArrivalTime = (string)point.Attribute("wta") ?? string.Empty,
                         WorkingDepartureTime = (string)point.Attribute("wtd") ?? string.Empty,
                         WorkingPassTime = (string)point.Attribute("wtp") ?? string.Empty
                     }).ToList(),
                     CancellationReason = journey.Descendants().FirstOrDefault(x => x.Name.LocalName == "cancelReason")?.Value ?? string.Empty
                 }).ToList();

            var associations = (from association in timetable.Root.Elements(scheduleNamespace + "Association")
                                select new DarwinScheduleAssociation
                                {
                                    TiplocCode = (string)association.Attribute("tiploc"),
                                    Category = (string)association.Attribute("category"),

                                    MainRid = (string)association.Element(scheduleNamespace + "main").Attribute("rid"),
                                    AssocRid = (string)association.Element(scheduleNamespace + "assoc").Attribute("rid"),

                                    MainPublicArrivalTime = (string)association.Element(scheduleNamespace + "main").Attribute("pta") ?? string.Empty,
                                    MainPublicDepartureTime = (string)association.Element(scheduleNamespace + "main").Attribute("ptd") ?? string.Empty,
                                    MainWorkingArrivalTime = (string)association.Element(scheduleNamespace + "main").Attribute("wta") ?? string.Empty,
                                    MainWorkingDepartureTime = (string)association.Element(scheduleNamespace + "main").Attribute("wtd") ?? string.Empty,

                                    AssocPublicArrivalTime = (string)association.Element(scheduleNamespace + "assoc").Attribute("pta") ?? string.Empty,
                                    AssocPublicDepartureTime = (string)association.Element(scheduleNamespace + "assoc").Attribute("ptd") ?? string.Empty,
                                    AssocWorkingArrivalTime = (string)association.Element(scheduleNamespace + "assoc").Attribute("wta") ?? string.Empty,
                                    AssocWorkingDepartureTime = (string)association.Element(scheduleNamespace + "assoc").Attribute("wtd") ?? string.Empty
                                }).ToList();

            var timetableId = (string)timetable.Root.Attribute("timetableID");

            return new DarwinSchedule
            {
                Associations = associations,
                Journeys = journeys,
                TimetableId = timetableId
            };
        }
    }
}