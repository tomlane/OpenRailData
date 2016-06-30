using System;
using OpenRailData.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public interface ITrainMovementContext : IContext, IDisposable
    {
    }
}
