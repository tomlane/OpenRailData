using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleManager
    {
        IList<IScheduleRecord> ParseScheduleEntites(string scheduleFilePath);
        void SaveScheduleEntities(IList<IScheduleRecord> entites);
    }
}