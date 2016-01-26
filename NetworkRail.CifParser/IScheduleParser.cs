using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleParser
    {
        IList<ICifRecord> ParseScheduleFile(IEnumerable<string> recordsToParse);
    }
}