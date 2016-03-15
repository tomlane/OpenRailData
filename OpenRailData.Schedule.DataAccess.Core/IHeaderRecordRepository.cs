using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.DataAccess.Core
{
    public interface IHeaderRecordRepository
    {
        void InsertRecord(HeaderRecord record);

        IEnumerable<HeaderRecord> GetRecentUpdates(int count = 1);
    }
}