using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleManager
    {
        IList<ICifRecord> ParseScheduleEntites(string scheduleFilePath);
        void SaveScheduleEntities(IList<ICifRecord> entites);
    }
}