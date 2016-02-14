using System;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleDatabase
{
    public interface IScheduleContext : IContext, IDisposable
    {
    }
}
