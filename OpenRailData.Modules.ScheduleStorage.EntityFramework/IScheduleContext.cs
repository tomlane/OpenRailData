using System;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework
{
    public interface IScheduleContext : IContext, IDisposable
    {
    }
}
