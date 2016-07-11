using System.Collections.Generic;

namespace OpenRailData.Domain.DarwinSchedule
{
    public class DarwinSchedule
    {
        public string TimetableId { get; set; }
        public List<DarwinScheduleJourney> Journeys { get; set; }
        public List<DarwinScheduleAssociation> Associations { get; set; }
    }
}