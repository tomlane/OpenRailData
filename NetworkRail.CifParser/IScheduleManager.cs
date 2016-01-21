using System.IO;

namespace NetworkRail.CifParser
{
    public interface IScheduleManager
    {
        CifScheduleEntityCollection ParseScheduleEntites(Stream scheduleStream);
        void SaveScheduleEntities(CifScheduleEntityCollection entites);
    }
}