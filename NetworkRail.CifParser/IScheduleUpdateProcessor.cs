using System.IO;

namespace NetworkRail.CifParser
{
    public interface IScheduleUpdateProcessor
    {
        CifScheduleRecordCollection ParseScheduleUpdate(Stream scheduleStream);
    }
}