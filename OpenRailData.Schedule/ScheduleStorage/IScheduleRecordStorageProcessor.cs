using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleRecordStorageProcessor
    {
        ScheduleRecordType RecordKey { get; }

        Task StoreRecord(IScheduleRecord record);
    }
}