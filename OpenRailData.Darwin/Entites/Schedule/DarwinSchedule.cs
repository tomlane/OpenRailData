using System.Collections.Generic;

namespace OpenRailData.Darwin.Entites.Schedule
{
    public class DarwinSchedule
    {
        public string TimetableId { get; set; }
        public List<DarwinScheduleJourney> Journeys { get; set; }
        public List<DarwinScheduleAssociation> Associations { get; set; }
    }
}