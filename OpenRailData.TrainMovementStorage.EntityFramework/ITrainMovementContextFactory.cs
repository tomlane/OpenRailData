namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public interface ITrainMovementContextFactory
    {
        TrainMovementContext Create();
    }
}