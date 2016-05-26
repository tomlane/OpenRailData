using System;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public interface ITrainMovementContext : IContext, IDisposable
    {
    }
}
