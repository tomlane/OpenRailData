using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using OpenRailData.Darwin.ScheduleDeserialization;
using OpenRailData.Domain.DarwinSchedule;

namespace OpenRailData.Darwin.ScheduleParsing
{
    public class XmlDarwinScheduleParser : IDarwinScheduleParser
    {
        public DarwinSchedule ParseSchedule(string rawSchedule)
        {
            if (string.IsNullOrWhiteSpace(rawSchedule))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(rawSchedule));

            var serializer = new XmlSerializer(typeof(DeserializedDarwinSchedule));

            DeserializedDarwinSchedule deserializedDarwinSchedule;

            using (var stringReader = new StringReader(rawSchedule))
            {
                deserializedDarwinSchedule = (DeserializedDarwinSchedule) serializer.Deserialize(stringReader);
            }

            return new DarwinSchedule
            {
                TimetableId = deserializedDarwinSchedule.TimetableId,
                Journeys = deserializedDarwinSchedule.DeserializedDarwinJourneys.Select(ConvertDarwinScheduleJourney).ToList(),
                Associations = deserializedDarwinSchedule.DeserializedDarwinAssociations.Select(ConvertDarwinScheduleAssociation).ToList()
            };
        }

        private DarwinScheduleAssociation ConvertDarwinScheduleAssociation(DeserializedDarwinAssociation deserializedDarwinAssociation)
        {
            return new DarwinScheduleAssociation
            {
                MainRid = deserializedDarwinAssociation.Main.Rid,
                MainPublicArrivalTime = deserializedDarwinAssociation.Main.PublicArrivalTime,
                MainPublicDepartureTime = deserializedDarwinAssociation.Main.PublicDepartureTime,
                MainWorkingArrivalTime = deserializedDarwinAssociation.Main.WorkingArrivalTime,
                MainWorkingDepartureTime = deserializedDarwinAssociation.Main.WorkingDepartureTime,

                AssocRid = deserializedDarwinAssociation.Assoc.Rid,
                AssocPublicArrivalTime = deserializedDarwinAssociation.Assoc.PublicArrivalTime,
                AssocPublicDepartureTime = deserializedDarwinAssociation.Assoc.PublicDepartureTime,
                AssocWorkingArrivalTime = deserializedDarwinAssociation.Assoc.WorkingArrivalTime,
                AssocWorkingDepartureTime = deserializedDarwinAssociation.Assoc.WorkingDepartureTime
            };
        }

        private DarwinScheduleJourney ConvertDarwinScheduleJourney(DeserializedDarwinJourney deserializedDarwinJourney)
        {
            return new DarwinScheduleJourney
            {                
                IsPassengerService = deserializedDarwinJourney.PassengerService,
                Rid = deserializedDarwinJourney.Rid,
                //SchedulePoints = deserializedDarwinJourney.DeserializedDarwinJourneyPoints.Select(ConvertDarwinPoint).ToList(),
                ScheduleStartDate = DateTime.Parse(deserializedDarwinJourney.ScheduleStartDate),
                Toc = deserializedDarwinJourney.TrainOperatingCompany,
                TrainCategory = deserializedDarwinJourney.TrainCategory,
                TrainId = deserializedDarwinJourney.TrainId,
                Uid = deserializedDarwinJourney.Uid,
                TrainStatus = deserializedDarwinJourney.TrainStatus
            };
        }

        //private DarwinSchedulePoint ConvertDarwinPoint(DeserializedDarwinJourneyPoint deserializedDarwinPoint)
        //{
        //    return new DarwinSchedulePoint
        //    {
        //        // TODO: Schedule point type is not being set. 
        //        LocationActivity = deserializedDarwinPoint.LocationActivity,
        //        Platform = deserializedDarwinPoint.Platform,
        //        PublicArrivalTime = deserializedDarwinPoint.PublicArrivalTime,
        //        PublicDepartureTime = deserializedDarwinPoint.PublicDepartureTime,
        //        Tiploc = deserializedDarwinPoint.TiplocCode,
        //        WorkingArrivalTime = deserializedDarwinPoint.WorkingArrivalTime,
        //        WorkingDepartureTime = deserializedDarwinPoint.WorkingDepartureTime,
        //        WorkingPassTime = deserializedDarwinPoint.WorkingPassingTime
        //    };
        //}
    }
}