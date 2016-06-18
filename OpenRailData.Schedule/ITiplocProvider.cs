using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.Schedule
{
    public interface ITiplocProvider
    {
        Task<TiplocRecord> GetTiplocByCrs(string crs);
        Task<TiplocRecord> GetTiplocByStanox(string stanox);
    }
}