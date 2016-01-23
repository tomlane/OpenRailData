using System.Collections.Generic;
using System.IO;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleManager
    {
        IList<ICifRecord> ParseScheduleEntites(Stream scheduleStream);
        void SaveScheduleEntities(IList<ICifRecord> entites);
    }
}