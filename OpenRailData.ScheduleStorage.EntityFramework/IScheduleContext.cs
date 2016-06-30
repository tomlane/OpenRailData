using System;
using OpenRailData.CommonDatabase;

namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public interface IScheduleContext : IContext, IDisposable
    {
    }
}
