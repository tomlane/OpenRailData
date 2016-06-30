using Microsoft.Extensions.Options;

namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public interface IScheduleContextFactory
    {
        ScheduleContext Create(IOptions<ScheduleContextOptions> options);
    }
}