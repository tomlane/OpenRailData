using Microsoft.Extensions.Options;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public interface ITrainMovementContextFactory
    {
        TrainMovementContext Create(IOptions<TrainMovementContextOptions> options);
    }
}