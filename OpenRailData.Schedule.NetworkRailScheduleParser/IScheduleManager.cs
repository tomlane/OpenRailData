using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleManager
    {
        IList<IScheduleRecord> GetRecordsByScheduleFileUrl(string url);

        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords);

        void SaveScheduleRecords(IList<IScheduleRecord> scheduleRecordsToSave);
    }
}