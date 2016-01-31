using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleParser
    {
        IList<IScheduleRecord> ParseScheduleFile(IEnumerable<string> recordsToParse);
    }
}