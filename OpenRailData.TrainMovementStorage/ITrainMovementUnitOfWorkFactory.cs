namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementUnitOfWorkFactory
    {
        ITrainMovementUnitOfWork Create();
    }
}